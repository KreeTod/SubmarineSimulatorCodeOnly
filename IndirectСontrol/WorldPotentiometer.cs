using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldPotentiometer : InteracteblePanel
{
    [Header("Potentiometer Settings")]
    [SerializeField] private int _positionCount;
    [SerializeField] private int _currentPositionCount;

    [SerializeField] private Transform Rotator;

    [SerializeField] private float _minAngle;
    [SerializeField] private float _currentAngle;
    [SerializeField] private float _maxAngle;
    private void Update()
    {
        _currentPositionCount = Mathf.Clamp(_currentPositionCount, 0, _positionCount);
        _currentValue = _minValue + (((_maxValue - _minValue) / _positionCount) * _currentPositionCount);
        _currentAngle = _minAngle + (((_maxAngle - _minAngle) / _positionCount) * _currentPositionCount);
        Rotator.transform.localRotation = Quaternion.Euler(-90, _currentAngle, 0);
    }
    public override void Interact()
    {
        base.Interact();
        _currentPositionCount++;
    }
    public override void AlternativeInteract()
    {
        base.AlternativeInteract();
        _currentPositionCount--;
    }
}
