using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveState
{
    Walk,
    Run,
    SlowStep
}
public class Move : MonoBehaviour
{
    [SerializeField] private KeyCode _runKey = KeyCode.LeftShift;
    [SerializeField] private KeyCode _slowStepKey = KeyCode.LeftAlt;

    [SerializeField] private float _baseMoveSpeed = 5;
    [SerializeField] private float _runSpeedModifier = 1.5f;
    [SerializeField] private bool _isPressToRun = false;

    [SerializeField] private float _slowStepSpeedModifier = 0.5f;
    [SerializeField] private bool _isPressToSlowStep = false;

    private MoveState _currentMoveState;
    private float _currentSpeedModifier;

    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        Vector2 _moveVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        /////////////////////
        if (_isPressToSlowStep)
        {
            if (Input.GetKeyDown(_slowStepKey))
            {
                _currentMoveState = (_currentMoveState == MoveState.SlowStep) ? MoveState.Walk : MoveState.SlowStep;
            }
        }
        else if (!_isPressToSlowStep)
        {
            if (Input.GetKey(_slowStepKey)) { _currentMoveState = MoveState.SlowStep; }
            else { _currentMoveState = MoveState.Walk; }
        }
        /////////////////////
        if (_isPressToRun)
        {
            if (Input.GetKeyDown(_runKey) && _currentMoveState != MoveState.SlowStep)
            {
                _currentMoveState = (_currentMoveState == MoveState.Run) ? MoveState.Walk : MoveState.Run;
            }
        }
        else if (!_isPressToRun && _currentMoveState != MoveState.SlowStep)
        {
            if (Input.GetKey(_runKey)){_currentMoveState = MoveState.Run;}
            else{_currentMoveState = MoveState.Walk;}
        }
        /////////////////////


        switch (_currentMoveState)
        {
            case MoveState.Walk:
                _currentSpeedModifier = 1;
                break;
            case MoveState.Run:
                _currentSpeedModifier = _runSpeedModifier;
                break;
            case MoveState.SlowStep:
                _currentSpeedModifier = _slowStepSpeedModifier;
                break;
        }


        _rb.velocity = transform.forward * _moveVector.y * _baseMoveSpeed * _currentSpeedModifier
            + transform.right * _moveVector.x * _baseMoveSpeed * _currentSpeedModifier
            + transform.up * _rb.velocity.y;
    }
}