using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEngineRotor : WorldDevice
{
    [SerializeField] private float _forceForward;
    [SerializeField] private float _forceBackward;

    [SerializeField] private Transform _pointOfForce;
    [SerializeField] private float _currentForce;

    private Rigidbody _rb;
    private void Start()
    {
        _rb = GetComponentInParent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rb.AddForce(_pointOfForce.forward * _currentForce);
    }
}
