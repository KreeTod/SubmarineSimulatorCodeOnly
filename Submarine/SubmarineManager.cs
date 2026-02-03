using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineManager : MonoBehaviour
{
    [SerializeField] private float _bodyVolume;
    [SerializeField] private float _bodyWeight;

    [SerializeField] private float _allRoomVolume;
    [SerializeField] private float _allRoomWeight;

    [SerializeField] private float _totalVolume;
    [SerializeField] private float _totalWeight;


    [SerializeField] private List<GameObject> _allSubmarineRooms;

    private Rigidbody _rb;


    [SerializeField] private Vector3 _f_a;
    private void Start()
    {
        _rb = GetComponent<Rigidbody>();

        CalculateMass();
        CalculateVolume();
        _totalVolume = _bodyVolume + _allRoomVolume;
        _totalWeight = _bodyWeight + _allRoomWeight;

        _rb.mass = _totalWeight;
    }
    private void Update()
    {

    }
    private void FixedUpdate()
    {
        CalculateMass();
        CalculateVolume();
        _totalVolume = _bodyVolume + _allRoomVolume;
        _totalWeight = _bodyWeight + _allRoomWeight;
        _rb.mass = _totalWeight;
        _f_a = Vector3.up * -(float)CalculateForce(_totalVolume);
        _rb.AddForce(_f_a);
    }
    private double CalculateForce(float V)
    {
        double F_a = /*r*/(float)Constants.WaterRho * /*g*/Physics.gravity.y * /*V from liter to m^3*/(V * 0.001);
        return F_a;
    }
    private void CalculateMass()
    {
        _allRoomWeight = 0;
        foreach (GameObject item in _allSubmarineRooms)
        {
            _allRoomWeight += item.GetComponent<WorldRoom>().GetRoomMass();
        }
    }
    private void CalculateVolume()
    {
        _allRoomVolume = 0;
        foreach (GameObject item in _allSubmarineRooms)
        {
            _allRoomVolume += item.GetComponent<WorldRoom>().GetRoomVolume();
        }
    }
}
