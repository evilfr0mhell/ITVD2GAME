using System;
using System.Collections.Generic;

class Program
{
    static int health = 100;
    static List<string> inventory = new List<string> { "Меч", "Щит", "Зелье" };

    static void Main(string[] args)
    {
        while (true)
        {
            ShowMainMenu();
        }
    }

    static void ShowMainMenu()
    {
        Console.Clear();
        Console.WriteLine($"Здоровье: {health}");
        Console.WriteLine("Инвентарь:");
        for (int i = 0; i < inventory.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {inventory[i]}");
        }
        Console.WriteLine("1. Первая дверь");
        Console.WriteLine("2. Вторая дверь");
        Console.WriteLine("0. Выход");
        Console.Write("Выберите действие: ");

        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                ChooseFirstDoor();
                break;
            case "2":
                ChooseSecondDoor();
                break;
            case "0":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Неверный выбор, попробуйте еще раз.");
                Console.ReadKey();
                break;
        }
    }

    static void ChooseFirstDoor()
    {
        Console.Clear();
        Console.WriteLine("Вы выбрали первую дверь.");
        InteractWithInventory();
    }

    static void ChooseSecondDoor()
    {
        Console.Clear();
        Console.WriteLine("Вы выбрали вторую дверь.");
        InteractWithInventory();
    }

    static void InteractWithInventory()
    {
        Console.WriteLine("Выберите предмет из инвентаря (или 0 для выхода):");
        for (int i = 0; i < inventory.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {inventory[i]}");
        }
        Console.Write("Ваш выбор: ");

        string itemChoice = Console.ReadLine();
        if (itemChoice == "0")
        {
            return; // Вернуться в главное меню
        }

        int itemIndex;
        if (int.TryParse(itemChoice, out itemIndex) && itemIndex > 0 && itemIndex <= inventory.Count)
        {
            ConfirmAction(inventory[itemIndex - 1]);
        }
        else
        {
            Console.WriteLine("Неверный выбор, попробуйте снова.");
            Console.ReadKey();
        }
    }

    static void ConfirmAction(string item)
    {
        Console.Clear();
        Console.WriteLine($"Вы действительно хотите использовать {item}? (1. Да, 2. Нет)");
        string confirmation = Console.ReadLine();

        if (confirmation == "1")
        {
            Console.WriteLine($"Вы использовали {item}.");
            // Добавьте логику для использования предмета
            // Например, если это зелье, восстановление HP и т.д.
        }
        else if (confirmation == "2")
        {
            Console.WriteLine("Действие отменено.");
        }
        else
        {
            Console.WriteLine("Неверный выбор, возвращаемся в меню.");
        }
        Console.ReadKey(); // Ждем нажатия клавиши
    }
}