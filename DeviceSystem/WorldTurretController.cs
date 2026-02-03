using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTurretController : WorldDevice
{
    [SerializeField] private GameObject _proj;
    [SerializeField] private WorldTurret _turret;

    [SerializeField] private WorldJoystic _joystic;
    private Vector2 _controllVector;

    [SerializeReference] WorldTextPanel _ammoCount;
    [SerializeReference] GameObject _consoleDisplay;
    [SerializeReference] InteracteblePanel _spotLightSwitcher;

    private RenderTexture _renderTexture;
    private Texture _noEnergyTexture;
    private Material _renderMaterial;

    [SerializeReference] WorldTextPanel _azimuthDegrees;
    [SerializeReference] WorldTextPanel _altitudeDegrees;


    [SerializeField] Vector2 _currentRotation;
    private void Start()
    {
        _renderTexture = new RenderTexture(128,128,0);
        _turret.TurretCamera.targetTexture = _renderTexture;
        _renderMaterial = new Material(Shader.Find("Standard"));
        _renderMaterial.mainTexture = _renderTexture;
        _renderMaterial.SetTexture("_EmissionMap", _renderTexture);
        _renderMaterial.EnableKeyword("_EMISSION");
        _renderMaterial.SetColor("_EmissionColor", Color.white);
        _consoleDisplay.GetComponent<Renderer>().material = _renderMaterial;


        _joystic.onJoysticButtonDown.AddListener(shotFromTurret);
    }
    private void Update()
    {
        /*if (GetBroken() == true)
        {
            _rm.mainTexture = _noEnergyTexture;
        }
        else
        {
            _rm.mainTexture = _rt;
        }//*/
    }
    private void FixedUpdate()
    {
        _ammoCount.Value = $"{_turret.CurrentAmmoCount}";
        _turret.IsSpotLightWorks = (_spotLightSwitcher.CurrentValue == 0) ? false : true;
        _turret.SpotLight.SetActive(_turret.IsSpotLightWorks);
        

        _controllVector = _joystic.ValueVector2;

        _currentRotation.x += _turret.MaxTurretSpeedHorizontal * -_controllVector.x;
        _currentRotation.y += _turret.MaxTurretSpeedHorizontal * -_controllVector.y;

        if (_currentRotation.x > 360)
        {
            _currentRotation.x = 0;
        }
        else if (_currentRotation.x < 0)
        {
            _currentRotation.x = 360;
        }

        _currentRotation.y = Mathf.Clamp(_currentRotation.y, _turret.TurretMinAngleVertical, _turret.TurretMaxAngleVertical);
        //_currentRotation.y = Mathf.Clamp(_currentRotation.x, _turret.TurretMinAngleHorizontal,_turret.TurretMaxAngleHorizontal);

        _turret.TurretTransformHorizontal.localRotation = Quaternion.Euler(
            -90,
             -_currentRotation.x,
            0
            );

        _turret.TurretTransformVertical.localRotation = Quaternion.Euler(
           0,
           90,
            -_currentRotation.y
           );


        _azimuthDegrees.Value = $"{_currentRotation.x}";
        _altitudeDegrees.Value = $"{_currentRotation.y}";

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
