using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class suspension : MonoBehaviour
{
    [SerializeField] private List<GameObject> LeftSuspension;
    [SerializeField] private List<GameObject> RightSuspension;

    [SerializeField] private float LeftTrackSteerVector;
    [SerializeField] private float RightTrackSteerVector;

    [SerializeField] private float motorTorque;
    [SerializeField] private float BrakeTorque;

    public int rot;
    private void Start()
    {
        LeftTrackSteerVector = Mathf.Clamp(LeftTrackSteerVector, -1, 1);
        RightTrackSteerVector = Mathf.Clamp(RightTrackSteerVector, -1, 1);
        foreach (var item in LeftSuspension)
        {
            item.GetComponent<WheelCollider>().motorTorque = motorTorque;
            item.GetComponent<WheelCollider>().brakeTorque = BrakeTorque;
        }
        foreach (var item in RightSuspension)
        {
            item.GetComponent<WheelCollider>().motorTorque = motorTorque;
            item.GetComponent<WheelCollider>().brakeTorque = BrakeTorque;
        }
    }
    private void Update()
    {
        LeftTrackSteerVector = Input.GetKey(KeyCode.Q) ? 1 : (Input.GetKey(KeyCode.Z)) ? -1 : 0;
        RightTrackSteerVector = Input.GetKey(KeyCode.E) ? 1 : (Input.GetKey(KeyCode.C)) ? -1 : 0;


        foreach (var item in LeftSuspension)
        {
            item.GetComponent<WheelCollider>().rotationSpeed = rot * LeftTrackSteerVector;
        }
        foreach (var item in RightSuspension)
        {
            item.GetComponent<WheelCollider>().rotationSpeed = rot * RightTrackSteerVector;
        }
    }
}
