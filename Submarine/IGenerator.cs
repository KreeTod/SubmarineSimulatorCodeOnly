using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Generator : MonoBehaviour
{
    [SerializeField] private float _maxDurability;
    [SerializeField] private float _durability;

    ////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////
    [SerializeField] private InteracteblePanel _turnOnOffSwitcher;

    [SerializeField] private InteracteblePanel _changeReactorTemperathureButtonUp;
    [SerializeField] private InteracteblePanel _changeReactorTemperathureButtonDown;

    [SerializeField] private float _maxTemperathure;
    [SerializeField] private float _Temperathure;

    [SerializeField] private float _maxPowerGenerate;
    [SerializeField] private float _powerGenerate;

    ////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////

    [SerializeField] private int _maxInventorySize;
    [SerializeField] private List<WorldItem> _inventoryList = new List<WorldItem>();

    [SerializeField] private WorldItem uran;
    private void Start(){ EventScheduler.OnEverySecond += EventScheduler_OnEverySecond; }
    private void OnDestroy(){ EventScheduler.OnEverySecond -= EventScheduler_OnEverySecond; }
    private void Update()
    {

    }


    private void EventScheduler_OnEverySecond()
    {
        foreach (WorldItem item in _inventoryList)
        {
            if (item.Name == "Uranum Rod")
            {
                item.ChangeItemDurability(-1);
            }
        }
    }


    void AddItem(WorldItem item)
    {
        if (_inventoryList.Count <= _maxInventorySize)
        {
            _inventoryList.Add(item);
        }
    }
    void RemoveItem(WorldItem item)
    {
        if (_inventoryList.Contains(item))
        {
            _inventoryList.Add(item);
        }
    }
}

