using game;

public class Inventory
{
    private List<Item> items = new List<Item>();
    private List<Slot> equipmentSlots = new List<Slot>();  // Слоты для надевания

    public int MaxWeight { get; private set; }  // Максимальный вес, который может нести персонаж
    public int CurrentWeight => items.Sum(item => item.Weight);  // Текущий вес инвентаря

    // Добавим свойство EquipmentSlotsCount
    public int EquipmentSlotsCount => equipmentSlots.Count;  // Возвращает количество слотов для экипировки

    public Inventory(int maxWeight)
    {
        MaxWeight = maxWeight;
        // Инициализируем слоты для экипировки
        equipmentSlots.Add(new Slot());  // Слот для шлема
        equipmentSlots.Add(new Slot());  // Слот для брони
        equipmentSlots.Add(new Slot());  // Слот для оружия
    }

    public List<Item> GetItems()
    {
        return items;
    }

    public Slot GetEquipmentSlot(int index)
    {
        if (index < 0 || index >= equipmentSlots.Count)
        {
            Console.WriteLine("Неверный индекс слота.");
            return null;
        }
        return equipmentSlots[index];
    }

    public bool AddItem(Item item)
    {
        if (CurrentWeight + item.Weight <= MaxWeight)
        {
            items.Add(item);
            Console.WriteLine($"{item.Name} добавлен в инвентарь.");
            return true;
        }
        else
        {
            Console.WriteLine("Невозможно добавить предмет. Превышен предел веса.");
            return false;
        }
    }

    public bool RemoveItem(Item item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Console.WriteLine($"{item.Name} удалён из инвентаря.");
            return true;
        }
        else
        {
            Console.WriteLine("Предмет не найден в инвентаре.");
            return false;
        }
    }

    public void EquipItemToSlot(int slotIndex, Item item)
    {
        var slot = GetEquipmentSlot(slotIndex);
        if (slot != null)
        {
            slot.EquipItem(item);
        }
    }

    public void UnequipItemFromSlot(int slotIndex)
    {
        var slot = GetEquipmentSlot(slotIndex);
        if (slot != null)
        {
            slot.RemoveItem();
        }
    }
}
