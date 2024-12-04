using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
