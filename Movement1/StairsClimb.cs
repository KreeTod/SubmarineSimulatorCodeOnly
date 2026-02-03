using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsClimb : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private Collider _stairsTrigger;
    [SerializeField] private Transform _stairsCheckSphereCenter;
    //[SerializeField] private bool _isTouchStairs;
    [SerializeField] private LayerMask _stairsLayer;
    [SerializeField] private PhysicMaterial _stairsPhysicMaterial;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        //Physics.CheckSphere(_stairsCheckSphereCenter.position, 0.5f, _stairsLayer);
        if (Input.GetKey(KeyCode.Space) && Physics.CheckSphere(_stairsCheckSphereCenter.position, 0.75f, _stairsLayer))
        {
            //_rb.AddForce(Vector3.up * 10, ForceMode.Acceleration  );
            gameObject.transform.Translate(Vector3.up * 0.05f);
            //_isTouchStairs = false;
            _rb.velocity = new Vector3(0, 0, 0);
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("dasgfsdgsdgsgddgssdg");
        if (other.gameObject.layer == _stairsLayer)
        {
            //_isTouchStairs = true;
        }
        else
        {
            //_isTouchStairs = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == _stairsLayer)
        {
            //_isTouchStairs = true;
        }
    }

}
