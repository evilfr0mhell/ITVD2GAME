using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    public class Character
    {
        public string Name { get; set; }
        public int Strength { get; set; }  // Сила персонажа (ограничение по весу)

        public Character(string name, int strength)
        {
            Name = name;
            Strength = strength;
        }
    }
}
