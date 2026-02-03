using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldDoor : WorldDevice
{
    [SerializeField] private List<WorldUpDownButton> _doorOpenerButton;
    [SerializeField] private Transform _doorPartLeft;
    [SerializeField] private Transform _doorPartRight;

    [SerializeField] private float _minOffset;
    [SerializeField] private float _currentOffset;
    [SerializeField] private float _maxOffset;

    [SerializeField] private bool _isDoorOpened;

    [SerializeField] private AudioClip DoorSound;
    [SerializeField] private AudioSource _as;

    private void Awake()
    {
        foreach (WorldUpDownButton button in _doorOpenerButton)
        {
            button.onButtonDown.AddListener(SwitchDoorState);
        }
        _as = GetComponent<AudioSource>();
        _as.clip = DoorSound;
        _as.playOnAwake = false;
    }
    private void OnDestroy()
    {
        foreach (WorldUpDownButton button in _doorOpenerButton)
        {
            button.onButtonDown.RemoveListener(SwitchDoorState);
        }
    }
    private void FixedUpdate()
    {
        if (_isDoorOpened == true)
        {
            _currentOffset = _maxOffset;
        }
        else
        {
            _currentOffset = _minOffset;
        }
        _doorPartLeft.localPosition = new Vector3(_currentOffset,0,0);
        _doorPartRight.localPosition = new Vector3(-_currentOffset, 0, 0);
    }
    private void SwitchDoorState()
    {
        _isDoorOpened = !_isDoorOpened;
        _as.Play();
    }
}
