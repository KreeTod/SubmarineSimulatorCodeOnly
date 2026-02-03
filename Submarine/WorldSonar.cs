using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class WorldSonar : MonoBehaviour
{
    [SerializeField] private WorldPotentiometer _volumePotentiometer;
    [SerializeField] private WorldPotentiometer _angleStepPotentiometer;

    [SerializeField] private WorldUpDownButton _pushSonarButton;

    public int _textureSize;
    public float MaxDistance;

    private Texture2D _displayTexture;
    private Material _displayMaterial;


    [SerializeField] private Transform _sonarPosition;
    [SerializeField] private GameObject _displayObject;
    private Color[,] ColorMatrix = new Color[256, 256];

    [SerializeField] private float angleStep;

    private RaycastHit _hit;
    void sex() { Debug.Log("sex"); RaycastAndSetColor(); }
    void Start()
    {
        _pushSonarButton.onButtonDown.AddListener(sex);
        Shader _displayShader = Shader.Find("Standard");
        if (_displayShader != null)
        {
            _displayTexture = new Texture2D(_textureSize, _textureSize, TextureFormat.RGBA32, false);
            for (int x = 0; x < _textureSize; x++)
            {
                for (int y = 0; y < _textureSize; y++)
                {
                    _displayTexture.SetPixel(x, y, Color.black);
                }
            }
            _displayTexture.Apply();
            //_displayTexture.format = TextureFormat.ARGB32;
            _displayMaterial = new Material(_displayShader);
            _displayMaterial.mainTexture = _displayTexture;
            _displayObject.GetComponent<Renderer>().material = _displayMaterial;
        }
        else { Debug.LogError("Cannot find Shader MutherFucker"); }
    }
    int tempint = 0;
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.W)) { Debug.DrawRay(_sonarPosition.position, _sonarPosition.forward, Color.red, 1); }
    }

    public Color closeColor = new Color(1, 0, 0);
    public Color farColor = new Color(0, 0, 1);
    private void RaycastAndSetColor()
    {
        Debug.Log(" RaycastAndSetColor();");
        Debug.DrawRay(_sonarPosition.position, _sonarPosition.forward, Color.red, 1);
        for (int x = 0; x < _textureSize; x++)
        {
            for (int y = 0; y < _textureSize; y++)
            {
                _displayTexture.SetPixel(x, y, Color.black);
            }
        }
        _displayTexture.Apply();
        ///////////////////////////////////////////////////////////////////////////////////////////
        for (int y = 0; y < _textureSize; y++)
        {
            for (int x = 0; x < _textureSize; x++)
            {
                
                Quaternion rotation = Quaternion.Euler(
                    (y - ((256 - 1) / 2f)) * angleStep,
                    (x - ((256 - 1) / 2f)) * angleStep,
                    0);
                Ray ray = new Ray(_sonarPosition.position, rotation * _sonarPosition.forward);
                Physics.Raycast(ray, out _hit, MaxDistance);

                if (_hit.distance > MaxDistance - 2 || _hit.distance == 0)
                {
                    //Debug.Log($"dist : {_hit.distance}, clr : {(_hit.distance / MaxDistance)}");
                    _displayTexture.SetPixel(256 - x, y, new Color(0, 0, 0));
                }
                else
                {
                    Debug.Log($"dist : {_hit.distance}, clr : {1 - (_hit.distance / MaxDistance)}");
                    _displayTexture.SetPixel(256 - x, y, new Color(0, 1 - (_hit.distance / MaxDistance), 0));
                }

            }
        }
        _displayTexture.Apply();
    }
}
