using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeaRain : MonoBehaviour
{
    public float advanceTime = 100f;
    void Start()
    {
        ParticleSystem ps = GetComponent<ParticleSystem>();

        ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        ps.Simulate(advanceTime, true, true, true);
        ps.Play();
    }
}
