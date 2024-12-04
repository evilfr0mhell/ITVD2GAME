using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    public class Item
    {
        public string Name { get; set; }
        public int Weight { get; set; }  // Вес предмета
        public int Size { get; set; }    // Количество ячеек, которые занимает предмет

        public Item(string name, int weight, int size)
        {
            Name = name;
            Weight = weight;
            Size = size;
        }
    }

}
