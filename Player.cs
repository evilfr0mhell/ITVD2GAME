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
}
