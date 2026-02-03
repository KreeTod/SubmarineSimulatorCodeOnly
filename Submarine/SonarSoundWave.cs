using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SonarSoundWave : MonoBehaviour
{

    [SerializeField] private float _SizeChangingSpeed;

    //private float WaterSoundSpeed = 1380.82f;
    [SerializeField] private GameObject _pingShpherePrefab;

    public  GameObject _touched;

    void Start()
    {
        
    }
    private void FixedUpdate()
    {
        gameObject.transform.localScale += new Vector3(_SizeChangingSpeed, _SizeChangingSpeed, _SizeChangingSpeed);
    }
    SonarSoundWave _tgc;
    private void OnTriggerEnter(Collider other)
    {
        if (
            //other != null
            //&& other.collider.TryGetComponent<SonarSoundWave>(out _tgc) == false
            //&& other.collider.tag == "Ground"
            other.gameObject != _touched)
        {
            _touched = other.gameObject;
            GameObject zzzz = Instantiate(_pingShpherePrefab);
            zzzz.GetComponent<SonarSoundWave>()._touched = other.gameObject;
            Destroy(gameObject);
        }
    }
}
