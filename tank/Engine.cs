using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Engine : MonoBehaviour
{
    [SerializeField] private Dictionary<int, int> _rpmToNM = new Dictionary<int, int>();

    [SerializeField] private float _inputThrottle;

    [SerializeField] private float _currentPower; //nm

    [SerializeField] private float _currentRPM;
    [SerializeField] private int _idleRPM;
    [SerializeField] private int _maxRPM;

    [SerializeField] private float _upSpeedPerTick;
    [SerializeField] private float _downSpeedPerTick;

    public AudioClip StartUpSound;
    public AudioClip IdleSound;
    public AudioClip RewUpSound;

    [SerializeField] private float _pitch;

    [SerializeField] private InteracteblePanel _inputThrottleSc;
    [SerializeField] private InteracteblePanel _inputIgnition;
    [SerializeField] private bool _isIgnition;

    private bool _isSrartingUp;
    private AudioSource _as;

    private void Awake()
    {
        _rpmToNM.Add(0, 0);
        _rpmToNM.Add(500, 50);
        _rpmToNM.Add(1000, 100);
        _rpmToNM.Add(1500, 150);
        _rpmToNM.Add(2000, 200);
        _rpmToNM.Add(2500, 250);
        _rpmToNM.Add(3000, 200);
        _rpmToNM.Add(3500, 100);
    }
    private void Start()
    {
        _as = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        _inputThrottle = _inputThrottleSc.CurrentValue;
        _isIgnition = (_inputIgnition.CurrentValue != 0) ? true : false;

        if (_inputThrottle != 0 && _isIgnition){ _currentRPM += _upSpeedPerTick * _inputThrottle; }
        else{ _currentRPM -= _downSpeedPerTick; }
        
        if (_currentRPM <= _idleRPM && _isIgnition) { _currentRPM += _upSpeedPerTick; }
        ///////////////////////////////////////////////////////////////////
        if (!_as.isPlaying)
        {
            _as.clip = IdleSound;
            _as.Play();
        }
        ////////////////////////////////////////////////////////////////
        _currentPower = CalculatePower(_currentRPM);
        _pitch = ConvertValue(_currentRPM, 0, _maxRPM, 0.3f, 3f);
        _as.pitch = _pitch;
        ////////////////////////////////////////////////////////////////
        _inputThrottle = Mathf.Clamp01(_inputThrottle);
        _currentRPM = Mathf.Clamp(_currentRPM, 0, _maxRPM);
        _pitch = Mathf.Clamp(_currentRPM, 0, 3);
    }
    float ConvertValue(float x, float min1, float max1, float min2, float max2)
    {
        return (x - min1) * (max2 - min2) / (max1 - min1) + min2;
    }




    private int CalculatePower(float rpm)
    {
        // Находим две ближайшие точки данных в словаре по RPM
        KeyValuePair<int, int> prevPoint = new KeyValuePair<int, int>(0, 0);
        KeyValuePair<int, int> nextPoint = new KeyValuePair<int, int>(3500, 100);

        foreach (var pair in _rpmToNM)
        {
            if (pair.Key <= rpm && pair.Key > prevPoint.Key)
            {
                prevPoint = pair;
            }
            else if (pair.Key >= rpm && pair.Key < nextPoint.Key)
            {
                nextPoint = pair;
            }
        }

        // Интерполируем мощность между ближайшими точками
        float t = (float)(rpm - prevPoint.Key) / (nextPoint.Key - prevPoint.Key);
        int interpolatedPower = Mathf.RoundToInt(Mathf.Lerp(prevPoint.Value, nextPoint.Value, t));

        return interpolatedPower;
    }
}


