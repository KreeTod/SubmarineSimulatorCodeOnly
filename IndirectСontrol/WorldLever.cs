using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldLever : InteracteblePanel
{
    [Header("Lever Settings")]

    [SerializeField] bool _isLeverMoveHorizontalOrRadial;

    [SerializeField] private bool _useAxisXElseY;

    [SerializeField] private int _positionCount;
    [SerializeField] private int _currentPositionCount;

    [SerializeField] private Transform _throttleLever;

    [SerializeField] private float _minOffset;
    [SerializeField] private float _currentOffset;
    [SerializeField] private float _maxOffset;


    [SerializeField] private float _minAngle;
    [SerializeField] private float _currentAngle;
    [SerializeField] private float _maxAngle;

    public int CurrentPositionCount { get => _currentPositionCount; }
    private void Update()
    {
        if (_isLeverMoveHorizontalOrRadial == false)
        {
            _currentPositionCount = Mathf.Clamp(_currentPositionCount, 0, _positionCount);
            _currentValue = _minValue + (((_maxValue - _minValue) / _positionCount) * _currentPositionCount);
            _currentAngle = _minAngle + (((_maxAngle - _minAngle) / _positionCount) * _currentPositionCount);
            _throttleLever.transform.localRotation = Quaternion.Euler(_currentAngle, 0, 0);
        }
        else
        {
            _currentPositionCount = Mathf.Clamp(_currentPositionCount, 0, _positionCount);
            _currentValue = _minValue + (((_maxValue - _minValue) / _positionCount) * _currentPositionCount);
            _currentOffset = _minOffset + (((_maxOffset - _minOffset) / _positionCount) * _currentPositionCount);
            _throttleLever.transform.localPosition = new Vector3(0,_currentOffset,0);
        }
    }
    public override void Interact(float x, float y)
    {
        base.Interact();
        _currentPositionCount = (_useAxisXElseY == true) ? (int)x : (int)y;
        _currentPositionCount = Mathf.Clamp(_currentPositionCount, 0, _positionCount);
    }
    public override void AlternativeInteract(float x, float y)
    {
        base.AlternativeInteract();
        _currentPositionCount = (_useAxisXElseY == true) ? (int)x : (int)y;
        _currentPositionCount = Mathf.Clamp(_currentPositionCount, 0, _positionCount);
    }
}
