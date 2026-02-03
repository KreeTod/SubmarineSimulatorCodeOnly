using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldShipController : WorldDevice
{
    [SerializeField] private WorldTextPanel _compasTextPanel;
    [SerializeField] private WorldTextPanel _depthTextPanel;
    [SerializeField] private WorldTextPanel _horizontalSpeedTextPanel;
    [SerializeField] private WorldTextPanel _vericalSpeedTextPanel;

    [SerializeField] private InteracteblePanel _ballastCameraPotentiometer;
    [SerializeField] private List<WorldRoom> _ballastRooms;

    [SerializeField] private InteracteblePanel _engineSpeedPotentiometer;
    [SerializeField] private WorldEngineController _wec;

    [SerializeField] private WorldLever _steeringLever;

    Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponentInParent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        _wec.Throttle = _engineSpeedPotentiometer.CurrentValue;
        _wec.Steer = _steeringLever.CurrentValue;

        Vector2 v2 = new Vector2(_rb.velocity.x, _rb.velocity.z);
        _compasTextPanel.Value = $"{transform.rotation.y}";
        _depthTextPanel.Value = $"Depth : {Mathf.Round(gameObject.GetComponentInParent<Transform>().position.y)}";
        _horizontalSpeedTextPanel.Value = $"Horizontal : {v2.magnitude * 3.6}";
        _vericalSpeedTextPanel.Value = $"Vertical : {_rb.velocity.y }";

        foreach (var item in _ballastRooms)
        {
            item.GetComponent<WorldRoom>().WaterProcent = _ballastCameraPotentiometer.CurrentValue;
        }

        //_wec.powerProcent = _engineSpeedPotentiometer.CurrentValue;
    }
}
