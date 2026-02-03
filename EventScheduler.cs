using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventScheduler : MonoBehaviour
{

    public delegate void MyEventHandler();
    public static event MyEventHandler OnEverySecond;

    private double _timerEverySecond;
    private void FixedUpdate()
    {
        _timerEverySecond += Time.fixedDeltaTime;
        if (_timerEverySecond >= 1)
        {
            OnEverySecond?.Invoke();
        }
    }
}
