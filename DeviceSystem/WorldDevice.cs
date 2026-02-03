using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
public enum DeviceType
{
    Generator,
    Consumer
}

public class WorldDevice : MonoBehaviour
{
    [SerializeField] protected string _deviceUIText;
    [SerializeField] protected string _deviceName;

    [SerializeField] protected float _maxDurability;
    [SerializeField] protected float _currentDurability;

    [SerializeField] protected bool _isBroken;

    [SerializeField] protected DeviceType _deviceType;

    [SerializeField] protected float _energyConsumption;

    [SerializeField] protected bool _isUsingEnergy;

    [SerializeField] protected WorldDevice _energyDealer;


    public bool GetBroken()
    {
        return (_currentDurability <= 0) ? true : false;
    }
    public void Break()
    {
        _currentDurability = 0;
    }
}
