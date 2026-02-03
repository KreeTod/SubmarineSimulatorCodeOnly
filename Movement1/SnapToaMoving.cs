using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapToaMoving : MonoBehaviour
{
    public LayerMask LayerToSnap;
    public GameObject CurrentSnapToParent;

    private Vector3 selfWorldPosition;
    private Vector3 snapWorldPosition;
    private Vector3 snapLocalPosition;
    private void OnTriggerEnter(Collider other)
    {
        if (other.includeLayers == LayerToSnap)
        {
            Debug.Log($"Snaped With {other.name}");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.includeLayers == LayerToSnap)
        {
            Debug.Log($"Un Snaped With {other.name}");
        }
    }
    private Rigidbody _rb;
    public Rigidbody _rbSnapped;
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        _rbSnapped = CurrentSnapToParent.GetComponent<Rigidbody>();
        if (_rbSnapped != null)
        {
            _rb.AddForce(new Vector3(_rbSnapped.velocity.x, 0, _rbSnapped.velocity.z), ForceMode.VelocityChange);
        }
    }
}
