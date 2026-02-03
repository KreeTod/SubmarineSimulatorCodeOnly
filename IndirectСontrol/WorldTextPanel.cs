using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldTextPanel : MonoBehaviour
{
    [SerializeField] protected string _uitext;
    [SerializeField] protected string _name;

    [SerializeField] private string _value;

    public string Value { get => _value; set => _value = value; }

    [SerializeField] private TMPro.TextMeshPro _tmp;
    private void Start()
    {
        if (_tmp == null) { Debug.LogError($"{gameObject.name}'s Mesh Pro NOT SET!"); }
    }
    private void FixedUpdate()
    {
        _tmp.text = _value;
    }
}
