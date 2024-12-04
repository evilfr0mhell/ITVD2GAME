using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    public class Slot
    {
        public Item ItemInSlot { get; set; }  // Предмет в слоте, если он есть

        public bool IsOccupied => ItemInSlot != null;  // Проверка, занят ли слот

        public void EquipItem(Item item)
        {
            if (!IsOccupied)
            {
                ItemInSlot = item;
                Console.WriteLine($"{item.Name} надет в слот.");
            }
            else
            {
                Console.WriteLine("Слот уже занят!");
            }
        }

        public void RemoveItem()
        {
            if (IsOccupied)
            {
                Console.WriteLine($"{ItemInSlot.Name} снят с слота.");
                ItemInSlot = null;
            }
            else
            {
                Console.WriteLine("Слот пуст.");
            }
        }
    }
}
