using System;
using game;

class Program
{
    static void Main(string[] args)
    {
        // Выбор игрока
        int playerChoice;
        do
        {
            Console.WriteLine("Выберите дверь: 1 , 2 ");
        } while (!int.TryParse(Console.ReadLine(), out playerChoice) || (playerChoice != 1 && playerChoice != 2));


        // Случайный выбор врага
        Random random = new Random();
        int enemyAction = random.Next(1, 3); // 1 - битва, 2 - разговор

        if (playerChoice == enemyAction)
        {
            if (playerChoice == 1)
            {
                Console.WriteLine("Я тебя убью!");

            }
            else
            {
                Console.WriteLine("Поговорим?");
                // Здесь можно добавить разговора

                // Создаем игроков для диалога
                Player player = new Player("Игрок");
                Player npc = new Player("NPC");

                // Начинаем диалог
                Dialogue dialogue = new Dialogue(player, npc);
                dialogue.StartConversation();
            }
        }

        Console.ReadKey();

        // Создание игры с передачей всех необходимых параметров в конструктор
        Game game = new Game("Варвар", 50, 100);  // Имя игрока, сила игрока, ёмкость инвентаря

        // Создание предметов
        Item sword = new Item("Меч", 15, 1);  // Меч, вес 15, занимает 1 ячейку
        Item shield = new Item("Щит", 20, 2);  // Щит, вес 20, занимает 2 ячейки
        Item armor = new Item("Броня", 30, 3);  // Броня, вес 30, занимает 3 ячейки

        // Добавление предметов в инвентарь
        game.AddItemToInventory(sword);
        game.AddItemToInventory(shield);
        game.AddItemToInventory(armor);

        // Проверка инвентаря
        game.CheckInventory();

        // Экипировка предметов
        game.EquipItemToSlot(0, sword);  // Надеваем меч в слот для оружия
        game.EquipItemToSlot(1, shield);  // Надеваем щит в слот для брони

        // Проверка экипировки
        game.CheckEquipment();

        // Попытка удалить предмет из инвентаря
        game.RemoveItemFromInventory(sword);  // Удаляем меч из инвентаря

        // Проверка инвентаря после удаления
        game.CheckInventory();
    }
}

namespace game
{
    // Класс, представляющий игрока
    public class Player
    {
        public string Name { get; private set; }

        public Player(string name)
        {
            Name = name;
        }

        public void Speak(string message)
        {
            Console.WriteLine($"{Name}: {message}");
        }
    }


    // Класс для управления диалогом между игроками
    public class Dialogue
    {
        private Player player1;
        private Player player2;

        public Dialogue(Player p1, Player p2)
        {
            player1 = p1;
            player2 = p2;
        }

        public void StartConversation()
        {
            Console.WriteLine("Игрок встретился с NPC:");
            player1.Speak("Привет, как дела?");
            player2.Speak("Привет! У меня всё хорошо, а у тебя?");
            player1.Speak("Тоже хорошо, спасибо!");
        }
    }
}