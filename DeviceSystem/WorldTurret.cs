using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WorldTurret : MonoBehaviour
{
    [SerializeField] private Transform _turretTransformHorizontal;
    [SerializeField] private Transform _turretTransformVertical;

    [SerializeField] private float _shotCoolDown;
    private float _shotCoolDownTimeLeft;

    [SerializeField] private float _turretMinAngleHorizontal;
    [SerializeField] private float _turretMaxAngleHorizontal;
    [SerializeField] private float _turretMinAngleVertical;
    [SerializeField] private float _turretMaxAngleVertical;

    [SerializeField] private Transform _projectileSpawnPoint;
    [SerializeField] private Camera _turretCamera;

    [SerializeField] private int _maxAmmoCount;
    [SerializeField] private int _currentAmmoCount;

    [SerializeField] private float _maxTurretSpeedHorizontal;
    [SerializeField] private float _maxTurretSpeedVertical;

    [SerializeField] private bool _isSpotLightWorks;
    [SerializeField] private GameObject _spotLight;

    private AudioSource _as;
    [SerializeField] private AudioClip _shotSound;
    private void Awake()
    {
        _currentAmmoCount = _maxAmmoCount;
        _as = gameObject.AddComponent<AudioSource>();
        _as.playOnAwake = false;
        _as.clip = _shotSound;
    }
    private void FixedUpdate()
    {
        _shotCoolDownTimeLeft += Time.fixedDeltaTime;
    }

    public Transform TurretTransformHorizontal { get => _turretTransformHorizontal; set => _turretTransformHorizontal = value; }
    public Transform TurretTransformVertical { get => _turretTransformVertical; set => _turretTransformVertical = value; }
    public Transform ProjectileSpawnPoint { get => _projectileSpawnPoint; set => _projectileSpawnPoint = value; }
    public float MaxTurretSpeedHorizontal { get => _maxTurretSpeedHorizontal; }
    public float MaxTurretSpeedVertical { get => _maxTurretSpeedVertical; }
    public float TurretMinAngleHorizontal { get => _turretMinAngleHorizontal; }
    public float TurretMaxAngleHorizontal { get => _turretMaxAngleHorizontal; }
    public float TurretMinAngleVertical { get => _turretMinAngleVertical;  }
    public float TurretMaxAngleVertical { get => _turretMaxAngleVertical;}
    public Camera TurretCamera { get => _turretCamera;}
    public int CurrentAmmoCount { get => _currentAmmoCount;/* set => _currentAmmoCount = value;*/ }
    public int MaxAmmoCount { get => _maxAmmoCount;}
    public bool IsSpotLightWorks { get => _isSpotLightWorks; set => _isSpotLightWorks = value; }
    public GameObject SpotLight { get => _spotLight; set => _spotLight = value; }

    public void Shot(GameObject projectile)
    {
        if (CurrentAmmoCount > 0 && _shotCoolDownTimeLeft >= _shotCoolDown)
        {
            GameObject gm = Instantiate(projectile, _projectileSpawnPoint.position, _projectileSpawnPoint.rotation);
            _currentAmmoCount--;
            _shotCoolDownTimeLeft = 0;
            _as.pitch = Random.Range(0.9f, 1.1f);
            _as.Play();
        }
    }
}

