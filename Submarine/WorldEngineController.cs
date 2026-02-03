using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldEngineController : WorldDevice
{
    [SerializeField] public float Throttle;
    [SerializeField] public float Steer;

    [SerializeField] private float _forceForward;
    [SerializeField] private float _forceBackward;

    [SerializeField] private float _forceSteer;

    [SerializeField] private Transform _pointOfForce;
    [SerializeField] private float _currentForwardForce;
    [SerializeField] private float _currentSteerForce;

    private Rigidbody _rb;
    private void Start()
    {
        _rb = GetComponentInParent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _rb.AddForceAtPosition(_pointOfForce.forward * _forceForward * Throttle, _pointOfForce.position);
        _rb.AddForceAtPosition(_pointOfForce.right * _forceSteer * Steer, _pointOfForce.position);
    }

    public void SetForceLevel(float value)
    {
        value = Mathf.Clamp(value, -1, 1);
    }
}
