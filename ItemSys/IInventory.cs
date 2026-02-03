using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInventory
{
    List<Item> Items { get; set; }

    void AddItem(Item item);
    void RemoveItem(Item item);
    Item FindItemByName(string name);
    List<Item> GetAllItems();
}
