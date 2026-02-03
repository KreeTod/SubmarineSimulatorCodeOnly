using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactorBlock : WorldDevice
{
    [SerializeField] private float _fuelTemperature;
    [SerializeField] private float _fuelTemperatureEfficient;           // between 0 and 1;
    [SerializeField] private float _fuelTemperatureMinimal = 600;       // 600
    [SerializeField] private float _fuelTemperatureOptimal = 1000;      // 1000
    [SerializeField] private float _fuelTemperatureCritial = 1800;      // 1800 градусов

    [SerializeField] private float _coolantTemperature;
    [SerializeField] private float _coolantTemperatureEfficient;        // between 0 and 1;
    [SerializeField] private float _coolantTemperatureMinimal = 170;    // 170
    [SerializeField] private float _coolantTemperatureOptimal = 300;    // 300
    [SerializeField] private float _coolantTemperatureCritical = 370;   // 370 градусов

    [SerializeField] private float _reactorPressure;
    [SerializeField] private float _reactorPressureEfficient;           // between 0 and 1;
    [SerializeField] private float _reactorPressureMinimal = 10000000;  // 10 MPa
    [SerializeField] private float _reactorPressureOptimal = 15000000;  // 15 MPa
    [SerializeField] private float _reactorPressureCritical = 18000000; // 18 MPa

    [SerializeField] private float _outputPower;
    public float OutputPower { get => _outputPower; }
    [SerializeField] private float _maxOutputPower;

    private void Awake()
    {
        _deviceType = DeviceType.Generator;
    }

    private void FixedUpdate()
    {
        if (_fuelTemperature > _fuelTemperatureMinimal)
        {
            _fuelTemperatureEfficient = ConvertToRange(
                _fuelTemperature - _fuelTemperatureMinimal,
                0,
                _fuelTemperatureCritial - _fuelTemperatureMinimal);
        } else { _fuelTemperatureEfficient = 0; }

        if (_coolantTemperature > _coolantTemperatureMinimal)
        {
            _coolantTemperatureEfficient = ConvertToRange(
                _coolantTemperature - _coolantTemperatureMinimal,
                0,
                _coolantTemperatureCritical - _coolantTemperatureMinimal);
        }
        else { _coolantTemperatureEfficient = 0; }

        if (_reactorPressure > _reactorPressureMinimal)
        {
            _reactorPressureEfficient = ConvertToRange(
                _reactorPressure - _reactorPressureMinimal,
                0,
                _reactorPressureCritical - _reactorPressureMinimal);
        }
        else { _reactorPressureEfficient = 0; }

        _outputPower = _maxOutputPower * _fuelTemperatureEfficient * _coolantTemperatureEfficient * _reactorPressureEfficient;
        if (_fuelTemperatureEfficient >= 1 || _coolantTemperatureEfficient >= 1 || _reactorPressureEfficient >= 1)
        {
            Break();
        }
    }

    public static float ConvertToRange(float value, float min, float max)
    {
        return (value - min) / (max - min);
    }
}
