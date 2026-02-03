using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Shelf : MonoBehaviour, IInventory
{
    public List<Item> Items { get; set; } = new List<Item>();

    public void AddItem(Item item)
    {
        Items.Add(item);
    }

    public void RemoveItem(Item item)
    {
        Items.Remove(item);
    }

    public Item FindItemByName(string name)
    {
        return Items.FirstOrDefault(item => item.Name == name);
    }

    public List<Item> GetAllItems()
    {
        return Items;
    }
}
