using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string _name;
    public string Name { get => _name; set => _name = value; }

    [SerializeField] private int _durability;
    public int Durability { get => _durability; set => _durability = value; }

    [SerializeField] private Sprite _icon;
    public Sprite Icon { get => _icon; set => _icon = value; }

    public Item(string name, int durability, Sprite icon)
    {
        _name = name;
        _durability = durability;
        _icon = icon;
    }

}
