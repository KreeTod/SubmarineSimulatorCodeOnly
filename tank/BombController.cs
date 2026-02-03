using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    [SerializeField] private WorldUpDownButton Num1Button;
    [SerializeField] private WorldUpDownButton Num2Button;
    [SerializeField] private WorldUpDownButton Num3Button;
    [SerializeField] private WorldUpDownButton Num4Button;
    [SerializeField] private WorldUpDownButton Num5Button;
    [SerializeField] private WorldUpDownButton Num6Button;
    [SerializeField] private WorldUpDownButton Num7Button;
    [SerializeField] private WorldUpDownButton Num8Button;
    [SerializeField] private WorldUpDownButton Num9Button;
    [SerializeField] private WorldUpDownButton Num0Button;
    [SerializeField] private WorldUpDownButton DeclineButton;
    [SerializeField] private WorldUpDownButton AcceptButton;

    [SerializeField] private WorldSwitcher SideSwitcher;

    [SerializeField] private AudioClip ExplodeSound;
    [SerializeField] private AudioClip ClickSound;
    [SerializeField] private AudioClip AcceptSound;


    private AudioSource _as;
    [SerializeField] private bool isplayfyyef;
    private void Start()
    {
        _as = GetComponent<AudioSource>();
        Num0Button.onButtonDown.AddListener(OnNum0);
        Num1Button.onButtonDown.AddListener(OnNum1);
        Num2Button.onButtonDown.AddListener(OnNum2);
        Num3Button.onButtonDown.AddListener(OnNum3);
        Num4Button.onButtonDown.AddListener(OnNum4);
        Num5Button.onButtonDown.AddListener(OnNum5);
        Num6Button.onButtonDown.AddListener(OnNum6);
        Num7Button.onButtonDown.AddListener(OnNum7);
        Num8Button.onButtonDown.AddListener(OnNum8);
        Num9Button.onButtonDown.AddListener(OnNum9);
        AcceptButton.onButtonDown.AddListener(OnAccept  );
        DeclineButton.onButtonDown.AddListener(OnDecline);
    }
    [SerializeReference] private string _password = "1234567890";
    [SerializeReference] private string _passwordCurrent = "";
    private void Update()
    {

    }
    private void PlayClickSound() 
    {
            _as.clip = ClickSound;
            _as.pitch = 3;
            _as.Play();
    }
    private void PlayExplodeSound() { }
    private void PlayAcceptSound() { }
    private void OnNum0() { if (SideSwitcher.CurrentValue != 0) { _passwordCurrent += "0"; PlayClickSound(); } }
    private void OnNum1() { if (SideSwitcher.CurrentValue != 0) { _passwordCurrent += "1"; PlayClickSound(); } }
    private void OnNum2() { if (SideSwitcher.CurrentValue != 0) { _passwordCurrent += "2"; PlayClickSound(); } }
    private void OnNum3() { if (SideSwitcher.CurrentValue != 0) { _passwordCurrent += "3"; PlayClickSound(); } }
    private void OnNum4() { if (SideSwitcher.CurrentValue != 0) { _passwordCurrent += "4"; PlayClickSound(); } }
    private void OnNum5() { if (SideSwitcher.CurrentValue != 0) { _passwordCurrent += "5"; PlayClickSound(); } }
    private void OnNum6() { if (SideSwitcher.CurrentValue != 0) { _passwordCurrent += "6"; PlayClickSound(); } }
    private void OnNum7() { if (SideSwitcher.CurrentValue != 0) { _passwordCurrent += "7"; PlayClickSound(); } }
    private void OnNum8() { if (SideSwitcher.CurrentValue != 0) { _passwordCurrent += "8"; PlayClickSound(); } }
    private void OnNum9() { if (SideSwitcher.CurrentValue != 0) { _passwordCurrent += "9"; PlayClickSound(); } }
    private void OnDecline() 
    {
        if (SideSwitcher.CurrentValue != 0)
        {
            _as.clip = ClickSound;
            _as.pitch = 3;
            _as.Play();
            _passwordCurrent = "";
        }
    }
    private void OnAccept() 
    {
        if (SideSwitcher.CurrentValue != 0)
        {
            if (_passwordCurrent == _password)
            {
                _as.clip = AcceptSound;
                _as.pitch = 1;
                _as.Play();
                _passwordCurrent = "";
            }
            else
            {
                _as.clip = ExplodeSound;
                _as.pitch = 1;
                _as.Play();
                _passwordCurrent = "";
            }
        }
    }
}
