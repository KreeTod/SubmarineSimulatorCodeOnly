using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{
    [SerializeField] private GameObject _proj; 
    [SerializeField] private WorldTurret _turret;

    [SerializeField] private WorldJoystic _joystic;
    private Vector2 _controllVector;

    [SerializeField] Vector2 _currentRotation;
    private void Start()
    {
        _joystic.onJoysticButtonDown.AddListener(shotFromTurret);
    }
    private void FixedUpdate()
    {
        _controllVector = _joystic.ValueVector2;


        _currentRotation.x += _turret.MaxTurretSpeedHorizontal * _controllVector.x;
        _currentRotation.y += _turret.MaxTurretSpeedHorizontal * _controllVector.y;

        _currentRotation.y = Mathf.Clamp(_currentRotation.y, _turret.TurretMinAngleVertical,_turret.TurretMaxAngleVertical);
        //_currentRotation.y = Mathf.Clamp(_currentRotation.x, _turret.TurretMinAngleHorizontal,_turret.TurretMaxAngleHorizontal);

        _turret.TurretTransformHorizontal.localRotation = Quaternion.Euler(
            -90,
             _currentRotation.x,
            0
            );

        _turret.TurretTransformVertical.localRotation = Quaternion.Euler(
           0,
           90,
            -_currentRotation.y
           );
    }

    private void OnDestroy()
    {
        _joystic.onJoysticButtonDown.RemoveListener(shotFromTurret);
    }

    private void shotFromTurret()
    {
        _turret.Shot(_proj);
    }
}
