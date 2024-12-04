using System;
using System.Collections.Generic;
using game;

public class Game
{
    private Character player;  // Игрок
    private Inventory inventory;  // Инвентарь игрока

    public Game(string playerName, int playerStrength, int inventoryCapacity)
    {
        // Создание персонажа
        player = new Character(playerName, playerStrength);

        // Создание инвентаря
        inventory = new Inventory(inventoryCapacity);
    }

    // Метод для добавления предмета в инвентарь
    public void AddItemToInventory(Item item)
    {
        if (!inventory.AddItem(item))
        {
            Console.WriteLine("Не удалось добавить предмет в инвентарь.");
        }
    }

    // Метод для удаления предмета из инвентаря
    public void RemoveItemFromInventory(Item item)
    {
        if (!inventory.RemoveItem(item))
        {
            Console.WriteLine("Не удалось удалить предмет из инвентаря.");
        }
    }

    // Метод для экипировки предмета
    public void EquipItemToSlot(int slotIndex, Item item)
    {
        inventory.EquipItemToSlot(slotIndex, item);
    }

    // Метод для снятия предмета с экипировки
    public void UnequipItemFromSlot(int slotIndex)
    {
        inventory.UnequipItemFromSlot(slotIndex);
    }

    // Метод для проверки инвентаря
    public void CheckInventory()
    {
        Console.WriteLine($"Инвентарь игрока {player.Name}:");
        foreach (var item in inventory.GetItems())
        {
            Console.WriteLine($"- {item.Name} (Вес: {item.Weight}, Размер: {item.Size})");
        }
    }

    // Метод для проверки экипировки
    public void CheckEquipment()
    {
        Console.WriteLine("Экипировка игрока:");
        for (int i = 0; i < inventory.EquipmentSlotsCount; i++)
        {
            var slot = inventory.GetEquipmentSlot(i);
            if (slot.IsOccupied)
            {
                Console.WriteLine($"Слот {i}: {slot.ItemInSlot.Name}");
            }
            else
            {
                Console.WriteLine($"Слот {i}: Пусто");
            }
        }
    }
}
