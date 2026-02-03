using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractorReworked : MonoBehaviour
{
    [SerializeField] private float _interactDistance;
    [SerializeField] private Camera _playerCamera;

    [SerializeField] private InteracteblePanel _lastInteracteblePanel;
    [SerializeField] private InteracteblePanel _currentInteracteblePanel;

    [SerializeField] private KeyCode _interactKey = KeyCode.Mouse0;
    [SerializeField] private KeyCode _alternativeInteractKey = KeyCode.Mouse1;

    [SerializeField] private playerGUI _ui;

    [SerializeField] private bool _isInteractingNow = false;
    [SerializeField] private bool _isHasInteracteblePanel;
    [SerializeField] private LayerMask _interactLayer;
    private RaycastHit _hit;
    private Camera_movement _pcm;

    [SerializeField] private float _positionOnFirstInteractMoment;
    [SerializeField] private Vector2 _vectorOnFirstInteractMoment;
    [SerializeField] private Vector2 _interactVector;

    private void Start()
    {
        _pcm = GetComponent<Camera_movement>();
    }

    private void Update()
    {
        Ray ray = new Ray(_playerCamera.transform.position, _playerCamera.transform.forward);
        if (Physics.Raycast(ray, out _hit, _interactDistance, _interactLayer))
        {
            if (_hit.collider.TryGetComponent<InteracteblePanel>(out _currentInteracteblePanel))
            {
                //_ui.SetInteractionText(_currentInteracteblePanel.GetUIText());
                _isHasInteracteblePanel = true;
                _ui.SetInteractionText($"{_currentInteracteblePanel.Uitext}");
            }
            //else if (_hit.collider.GetComponent<InteracteblePanel>())
            //{
            //    _ui.SetInteractionText(_currentInteracteblePanel.GetUIText());
            //    _isHasInteracteblePanel = true;
            //}
        }
        else
        {
            _ui.SetInteractionText("");

            _currentInteracteblePanel = null;
            _isHasInteracteblePanel = false;
        }
        /*if (_currentInteracteblePanel != null)
        {
            _ui.SetInteractionText($"{_currentInteracteblePanel.Uitext}");
        }*/


        if (Input.GetKey(_interactKey) || Input.GetKey(_alternativeInteractKey))
        {
            //_isInteractingNow = true;
            if (_currentInteracteblePanel != null)
            {
                _lastInteracteblePanel = _currentInteracteblePanel;
            }
        }

        if (_isInteractingNow)
        {
            _interactVector.x += Input.GetAxis("Mouse X");
            _interactVector.y += Input.GetAxis("Mouse Y");
            _pcm.LockCamera = true;
        }
        else
        {
            _pcm.LockCamera = false;
        }

        if (_lastInteracteblePanel != null)
        {
            _isHasInteracteblePanel = true;
        }

        if (_isHasInteracteblePanel)
        {
            if (_currentInteracteblePanel.ButtonType == ButtonType.BackToTop ||
                _currentInteracteblePanel.ButtonType == ButtonType.Potentiometer ||
                _currentInteracteblePanel.ButtonType == ButtonType.Switcher)
            {
                if (Input.GetKeyDown(_interactKey) || Input.GetKeyDown(_alternativeInteractKey))
                {
                    _isInteractingNow = true;
                    if (_currentInteracteblePanel != null)
                    {
                        _lastInteracteblePanel = _currentInteracteblePanel;
                    }
                }
                if (Input.GetKeyDown(_interactKey))
                {
                    _lastInteracteblePanel.Interact();
                }
                if (Input.GetKeyDown(_alternativeInteractKey))
                {
                    _lastInteracteblePanel.AlternativeInteract();
                }
            }
            else if (_currentInteracteblePanel.ButtonType == ButtonType.Lever)
            {
                if (Input.GetKey(_interactKey) || Input.GetKey(_alternativeInteractKey))
                {
                    if (_isInteractingNow == false)
                    {
                        _isInteractingNow = true;
                        _interactVector = new Vector2(0, 0);
                        _positionOnFirstInteractMoment = _lastInteracteblePanel.gameObject.GetComponent<WorldLever>().CurrentPositionCount;
                    }
                    else
                    {
                        _lastInteracteblePanel.Interact(_positionOnFirstInteractMoment + _interactVector.x, _positionOnFirstInteractMoment + _interactVector.y);
                    }
                }
            }
            else if (_currentInteracteblePanel.ButtonType == ButtonType.Joystic)
            {
                if (Input.GetKey(_interactKey))
                {
                    if (_isInteractingNow == false)
                    {
                        _isInteractingNow = true;
                        _interactVector = new Vector2(0, 0);
                        //_positionOnFirstInteractMoment = _lastInteracteblePanel.gameObject.GetComponent<WorldLever>().CurrentPositionCount;
                    }
                    else
                    {
                        _lastInteracteblePanel.Interact(_interactVector.x, _interactVector.y);
                    }
                }
                if (Input.GetKey(_alternativeInteractKey))
                {
                    _lastInteracteblePanel.AlternativeInteract();
                }
            }
        }
    }
    private void LateUpdate()
    {
        if (Input.GetKey(_interactKey) == false && Input.GetKey(_alternativeInteractKey) == false)
        {
            if (_lastInteracteblePanel != null)
            {
                if (_lastInteracteblePanel.ButtonType == ButtonType.Joystic) { _lastInteracteblePanel.Interact(0, 0); }
            }

            _isInteractingNow = false;
            _lastInteracteblePanel = null;
        }
    }
}