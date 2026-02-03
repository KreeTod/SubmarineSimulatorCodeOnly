using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WorldUpDownButton : InteracteblePanel
{
    [Header("UpDownButton Settings")]
    [SerializeField] private Transform ButtonModel;
    [SerializeField] private float _upOffset;
    [SerializeField] private float _downOffset;

    private bool _isButtonDown = false;

    public bool IsButtonDown { get => _isButtonDown; }
    public UnityEvent onButtonDown;

    private float _delay;
    private void Update()
    {
        if (_isButtonDown) { _currentValue = _maxValue; }
        else { _currentValue = _minValue; }
        if (_isButtonDown && _delay <= 0.12f)
        {
            ButtonModel.localPosition = new Vector3(0, _downOffset, 0);
            _delay += Time.deltaTime;
        }
        else
        {
            ButtonModel.localPosition = new Vector3(0, _upOffset, 0);
            _isButtonDown = false;
            _delay = 0;
        }
    }
    public override void Interact()
    {
        base.Interact();
        _isButtonDown = true;
        onButtonDown.Invoke();
    }
    public override void AlternativeInteract()
    {
        base.AlternativeInteract();
        _isButtonDown = true;
        onButtonDown.Invoke();
    }
}

