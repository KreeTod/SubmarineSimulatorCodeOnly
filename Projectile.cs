using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float _startForce;
    [SerializeField] private float _timeToDestroy;

    private Rigidbody _rb;

    private void Start()
    {
        Destroy(gameObject, _timeToDestroy);
        _rb = GetComponent<Rigidbody>();
        _rb.AddForce(gameObject.transform.up * _startForce);
    }
}
