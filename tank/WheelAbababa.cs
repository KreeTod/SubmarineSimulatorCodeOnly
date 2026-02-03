using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelAbababa : MonoBehaviour
{
    [SerializeField] private float _forwardFriction;
    [SerializeField] private float _sidewayFriction;

    public float ForwardFriction { get => _forwardFriction; }
    public float SidewayFriction { get => _sidewayFriction; }


}
