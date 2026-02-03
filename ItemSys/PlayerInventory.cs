using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour, IInventory
{
    public List<Item> Items { get; set; } = new List<Item>();
    [SerializeField] private List<Item> _items = new List<Item>();
    [SerializeField] private GameObject itemUIPrefab;
    [SerializeField] private Transform gridLayoutGroup;

    [SerializeField] private GameObject _inventoryPanel;
    [SerializeField] private bool _isInventoryOpened;

    private void Awake()
    {
        foreach (var item in _items)
        {
            Items.Add(item);
        }
        _inventoryPanel = GameObject.Find("InventoryPanel");
        gridLayoutGroup = GameObject.Find("OwnInventoryGrid").transform;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I)) { _isInventoryOpened = !_isInventoryOpened; }
        if (_isInventoryOpened)
        {
            _inventoryPanel.SetActive(true);
        }
        else
        {
            _inventoryPanel.SetActive(false);
        }
    }
    public void AddItem(Item item)
    {
        Items.Add(item);
        Debug.Log($"Item {item.Name} added to inventory.");
        UpdateUI();
    }

    public void RemoveItem(Item item)
    {
        if (Items.Contains(item))
        {
            Items.Remove(item);
            Debug.Log($"Item {item.Name} removed from inventory.");
            UpdateUI();
        }
        else
        {
            Debug.Log($"Item {item.Name} not found in inventory.");
        }
    }

    public Item FindItemByName(string name)
    {
        Item item = Items.FirstOrDefault(i => i.Name == name);
        if (item != null)
        {
            Debug.Log($"Item {name} found in inventory.");
        }
        else
        {
            Debug.Log($"Item {name} not found in inventory.");
        }
        return item;
    }

    public List<Item> GetAllItems()
    {
        return Items;
    }

    private void UpdateUI()
    {
        foreach (Transform child in gridLayoutGroup)
        {
            Destroy(child.gameObject);
        }

        foreach (Item item in Items)
        {
            GameObject itemUI = Instantiate(itemUIPrefab, gridLayoutGroup);
            itemUI.GetComponentInChildren<Text>().text = item.Name;
            itemUI.GetComponentInChildren<Image>().sprite = item.Icon;
        }
    }
}
