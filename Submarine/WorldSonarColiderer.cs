using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSonarColiderer : MonoBehaviour
{
    [SerializeField] private WorldUpDownButton _sonarPush;


    public AudioClip ping;
    public Transform PingTransform;


    [SerializeField] private GameObject _pingShpherePrefab;

    private AudioSource _as;
    //private  float WaterSoundSpeed = 1380.82f;

    private void Start()
    {
        _as = GetComponent<AudioSource>();

        _sonarPush.onButtonDown.AddListener(OnPingButtonDown);
    }
    private void OnDestroy()
    {
        _sonarPush.onButtonDown.RemoveListener(OnPingButtonDown);
    }

    private void Update()
    {
        
    }

    private void OnPingButtonDown()
    {
        _as.clip = ping;
        _as.Play();
        MakePingSphere();
    }

    private void MakePingSphere()
    {
        GameObject sphere = Instantiate(_pingShpherePrefab);
    }
}
