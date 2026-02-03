using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public enum ButtonType
{
    ButtonDown,
    ButtonDownUp,
    Switcher,
    Potentiometer,
    BackToTop,
    Lever,
    Joystic
}
public abstract class InteracteblePanel : MonoBehaviour
{
    [SerializeField] protected string _uitext;
    [SerializeField] protected string _name;

    [SerializeField] protected float _minValue;
    [SerializeField] protected float _currentValue;
    [SerializeField] protected float _maxValue;

    [SerializeField] private ButtonType buttonType;
    [SerializeField] protected Collider _triggerColliders;
    //private CrewControls _controlledMechanism;

    [SerializeField] private AudioClip _interactSound;
    private AudioSource _as;

    public float CurrentValue { get => _currentValue;}
    public ButtonType ButtonType { get => buttonType; }
    public string Uitext { get => _uitext; }
    private void Awake()
    {
        _as = gameObject.AddComponent<AudioSource>();
        _as.playOnAwake = false;
        _as.clip = _interactSound;
    }
    private void Start()
    {
        if (_triggerColliders == null)
        {
            _triggerColliders = GetComponent<Collider>();
            if (_triggerColliders == null) { Debug.LogError($"{gameObject.name}'s TriggerColliders NOT SET!"); }
            if (gameObject.layer != 6) { Debug.LogError($"{gameObject.name}'s layer IS NOT Interacteble Panel!"); }
        }
    }
    public string GetUIText(){ return _uitext; }

    virtual public void Interact() { if (_as.clip != null) { _as.Play(); } }
    virtual public void Interact(int positions){ if (_as.clip != null) { _as.Play(); } }
    virtual public void Interact(float x, float y){ }
    virtual public void AlternativeInteract() { if (_as.clip != null) { _as.Play(); } }
    virtual public void AlternativeInteract(int positions) { if (_as.clip != null) { _as.Play(); } }
    virtual public void AlternativeInteract(float x, float y) { }

}
