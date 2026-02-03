using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSwitcher : InteracteblePanel
{
    [Header("Potentiometer Settings")]
    [SerializeReference] private bool _isThreePosition;
    [SerializeReference] private int _positionCount;
    
    [SerializeReference] private int _currentPositionCount;

    [SerializeField] private Transform Rotator;

    [SerializeField] private float _minAngle;
    [SerializeField] private float _currentAngle;
    [SerializeField] private float _maxAngle;
    private void Update()
    {
        if (_isThreePosition) { _positionCount = 2; } else { _positionCount = 1; }
        _currentPositionCount = Mathf.Clamp(_currentPositionCount, 0, _positionCount);
        _currentValue = _minValue + (((_maxValue - _minValue) / _positionCount) * _currentPositionCount);
        _currentAngle = _minAngle + (((_maxAngle - _minAngle) / _positionCount) * _currentPositionCount);
        Rotator.transform.localRotation = Quaternion.Euler(-90 + _currentAngle, 0, 0);
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

