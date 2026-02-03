using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldBalasteController : MonoBehaviour
{
    [SerializeField] private WorldLever _waterBalancePotentiometer;

    [SerializeField] private List<GameObject> _balasteRooms = new List<GameObject>();
    private void Start()
    {
        
    }
    private void FixedUpdate()
    {
        foreach (var item in _balasteRooms)
        {
            item.GetComponent<WorldRoom>().WaterProcent = _waterBalancePotentiometer.CurrentValue;
        }
    }
}
