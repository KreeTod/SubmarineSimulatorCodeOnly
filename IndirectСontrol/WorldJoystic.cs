using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class WorldJoystic : InteracteblePanel
{
    public UnityEvent onJoysticButtonDown;


    [Header("Joystic Settings")]

    [SerializeField] private Vector2 _positionVector;
    [SerializeField] private Vector2 _currentPositionVector;

    [SerializeField] private Transform _throttleLever;

    [SerializeField] private Vector2 _valueVector2;

    [SerializeField] private float _minAngle;
    [SerializeField] private float _currentAngle;
    [SerializeField] private float _maxAngle;

    public Vector2 CurrentPositionCount { get => _currentPositionVector; }
    public Vector2 ValueVector2 { get => _valueVector2; set => _valueVector2 = value; }

    private void Update()
    {
        _currentPositionVector.x = Mathf.Clamp(_currentPositionVector.x, -1 , 1);
        _currentPositionVector.y = Mathf.Clamp(_currentPositionVector.y, -1 , 1);

        _valueVector2.x = _currentPositionVector.x;
        _valueVector2.y = _currentPositionVector.y;


        _throttleLever.localPosition = new Vector3(
            _maxAngle * _currentPositionVector.x,
            0,
            _maxAngle * _currentPositionVector.y);

        //_throttleLever.localRotation = Quaternion.Euler(
        //    -90 + (_maxAngle * _currentPositionVector.x),
        //    90 + (_maxAngle * _currentPositionVector.y),
        //    -90 + (_maxAngle * _currentPositionVector.y)
        //    );
    }
    public override void Interact(float x, float y)
    {
        base.Interact();
        _currentPositionVector = new Vector2(x * 0.01f, y * 0.01f);
        _currentPositionVector.x = Mathf.Clamp(_currentPositionVector.x, -1, 1);
        _currentPositionVector.y = Mathf.Clamp(_currentPositionVector.y, -1, 1);
    }
    public override void AlternativeInteract()
    {
        base.AlternativeInteract();
        onJoysticButtonDown.Invoke();
    }
}
