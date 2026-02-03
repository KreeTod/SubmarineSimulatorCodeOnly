using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldRoom : MonoBehaviour
{
    [SerializeField] private string _roomName;

    [SerializeField] private float _roomVolumeLiter;

    [SerializeField] private bool _isHasWaterPump;
    [SerializeField] private float _waterPumpPowerLiters;
    //[SerializeField] private float _airCount;
    [SerializeField] private float _waterProcent;

    [SerializeField] private bool _isWallToOut;
    public float WaterProcent { get => _waterProcent; set => _waterProcent = value; }

    public float GetRoomMass()
    {
        float value = (_roomVolumeLiter * (_waterProcent / 100)) * (float)Constants.WaterLiterMass;
        return value;
    }

    public float GetRoomVolume()
    {
        float value = _roomVolumeLiter;
        return value;
    }
}
