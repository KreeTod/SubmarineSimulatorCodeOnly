using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WorldItem : MonoBehaviour
{
    public string Name;

    public float MaxDurability;
    public float Durability;

    //public float MaxContent;
    //public float Content;

    public int quality;

    public void ChangeItemDurability(float value)
    {
        Durability += value;
    }
}
