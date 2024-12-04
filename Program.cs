using System;
using System.Collections.Generic;

class Program
{
    static int health = 100;
    static int score = 0;
    static List<string> inventory = new List<string>();
    static Random random = new Random();

    static void Main()
    {
        while (health > 0)
        {
            Console.Clear();
            Console.WriteLine($"Результат: {score}  Хп: {health}");
            Console.WriteLine("Инвентарь: " + (inventory.Count > 0 ? string.Join(", ", inventory) : "пуст"));

            Console.WriteLine("1. Выбор двери (1 или 2)");
            Console.WriteLine("2. Открыть инвентарь");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ChooseDoor();
                    break;
                case "2":
                    UseInventory();
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    break;
            }
        }

        Console.WriteLine("Игра окончена! Ваш результат: " + score);
    }

    static void ChooseDoor()
    {
        Console.WriteLine("Выберите дверь: 1 или 2");
        string door = Console.ReadLine();

        if (door == "1" || door == "2")
        {
            ShowDoor();
            int eventOutcome = random.Next(2);
            if (eventOutcome == 0)
            {
                Console.WriteLine("Вы прошли без приключений.");
                score++;
            }
            else
            {
                Encounter();
            }
        }
        else
        {
            Console.WriteLine("Неверный выбор. Возвращение в меню.");
        }

        Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
        Console.ReadKey();
    }

    static void Encounter()
    {
        int encounterType = random.Next(2);

        if (encounterType == 0)
        {
            ShowEnemy();
            Console.WriteLine("Вы встретили врага!");
            Console.WriteLine("1. Отбиться (60% шанс победить)");
            Console.WriteLine("2. Убежать (-50 ХП)");
            string action = Console.ReadLine();

            if (action == "1")
            {
                if (random.Next(100) < 60)
                {
                    Console.WriteLine("Вы победили врага и получили лут!");
                    GetLoot();
                }
                else
                {
                    Console.WriteLine("Вы проиграли битву. -50 ХП.");
                    health -= 50;
                }
            }
            else if (action == "2")
            {
                Console.WriteLine("Вы убежали, потеряв 50 ХП.");
                health -= 50;
            }
            else
            {
                Console.WriteLine("Неверный выбор. Враг атакует! -50 ХП.");
                health -= 50;
            }
        }
        else
        {
            ShowNPC();
            Console.WriteLine("Вы встретили НПС!");
            Console.WriteLine("1. Поговорить (получить лут)");
            Console.WriteLine("2. Игнорировать");
            string action = Console.ReadLine();

            if (action == "1")
            {
                Console.WriteLine("Вы поговорили с НПС и получили лут!");
                GetLoot();
            }
            else if (action == "2")
            {
                Console.WriteLine("Вы проигнорировали НПС.");
            }
            else
            {
                Console.WriteLine("Неверный выбор. НПС уходит.");
            }
        }
    }

    static void GetLoot()
    {
        int lootChance = random.Next(100);
        if (lootChance < 70)
        {
            Console.WriteLine("Вы получили Зелье здоровья (+50 ХП)!");
            inventory.Add("Зелье здоровья");
        }
        else if (lootChance < 90)
        {
            Console.WriteLine("Вы получили Зелье неуязвимости!");
            inventory.Add("Зелье неуязвимости");
        }
        else
        {
            Console.WriteLine("Вы получили Ключ от всех дверей (результат +5)!");
            inventory.Add("Ключ от всех дверей");
        }
    }

    static void UseInventory()
    {
        if (inventory.Count == 0)
        {
            Console.WriteLine("Ваш инвентарь пуст.");
            return;
        }

        Console.WriteLine("Ваш инвентарь:");
        for (int i = 0; i < inventory.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {inventory[i]}");
        }
        Console.WriteLine("Выберите предмет для использования (0 для выхода):");

        if (int.TryParse(Console.ReadLine(), out int itemIndex) && itemIndex > 0 && itemIndex <= inventory.Count)
        {
            string item = inventory[itemIndex - 1];
            Console.WriteLine($"Вы уверены, что хотите использовать {item}? (1. Да, 2. Нет)");

            if (Console.ReadLine() == "1")
            {
                UseItem(item);
                inventory.RemoveAt(itemIndex - 1);
            }
            else
            {
                Console.WriteLine("Действие отменено.");
            }
        }
        else
        {
            Console.WriteLine("Неверный выбор.");
        }

        Console.WriteLine("Нажмите любую клавишу, чтобы продолжить...");
        Console.ReadKey();
    }

    static void UseItem(string item)
    {
        switch (item)
        {
            case "Зелье здоровья":
                health = Math.Min(health + 50, 100);
                Console.WriteLine("Вы восстановили 50 ХП!");
                break;
            case "Зелье неуязвимости":
                Console.WriteLine("Вы активировали неуязвимость на один шаг!");
                break;
            case "Ключ от всех дверей":
                score += 5;
                Console.WriteLine("Ваш результат увеличился на 5!");
                break;
            default:
                Console.WriteLine("Неизвестный предмет.");
                break;
        }
    }

    static void ShowDoor()
    {
        Console.WriteLine(@"
  _______
 |       |
 |       |
 |   O   |
 |       |
 |_______|");
    }

    static void ShowEnemy()
    {
        Console.WriteLine(@"
              (
               )
              (
        /\  .-""""""-.  /\
       //\\/  ,,,  \//\\
       |/\| ,;;;;;, |/\|
       //\\\;-""""""-;///\\
      //  \/   .   \/  \\
     (| ,-_| \ | / |_-, |)
       //`__\.-.-./__`\\
      // /.-(() ())-.\ \\
     (\ |)   '---'   (| /)
      ` (|           |) `
        \)           (/");
    }

    static void ShowNPC()
    {
        Console.WriteLine(@"
                 ,#####,
                 #_   _#
                 |a` `a|
                 |  u  |
                 \  =  /
                 |\___/|
        ___ ____/:     :\____ ___
      .'   `.-===-\   /-===-.`   '.
     /      .-""""""""""-.-""""""""""-.      \
    /'             =:=             '\
  .'  ' .:    o   -=:=-   o    :. '  `.
  (.'   /'. '-.....-'-.....-' .'\   '.)
  /' ._/   "".     --:--     .""   \_. '\
 |  .'|      "".  ---:---  .""      |'.  |
 |  : |       |  ---:---  |       | :  |
  \ : |       |_____._____|       | : /
  /   (       |----|------|       )   \
 /... .|      |    |      |      |. ...\
|::::/'' jgs /     |       \     ''\::::|
'""""""""       /'    .L_      `\       """"""""'
           /'-.,__/` `\__..-'\
          ;      /     \      ;
          :     /       \     |
          |    /         \.   |
          |`../           |  ,/
          ( _ )           |  _)
          |   |           |   |
          |___|           \___|
          :===|            |==|
           \  /            |__|
           /\/\           /""""""`8.__
           |oo|           \__.//___)
           |==|
           \__/");
    }

}
