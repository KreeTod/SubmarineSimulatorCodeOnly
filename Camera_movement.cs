using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_movement : MonoBehaviour
{
    //-------------------------
    [SerializeField] private Camera PlayerCamera;
    [SerializeField] private Transform PlayerHeadTransform;
    [SerializeField] private Transform PlayerTransform;

    [SerializeField] private KeyCode ZoomKey = KeyCode.Z;
    private bool _isZooming;

    [SerializeField] private int _playerCameraFOV;
    [SerializeField] private int _playerCameraZoomFOV;

    [SerializeField] private float _sensivity = 1;
    [SerializeField] private bool _lockCursor;
    [SerializeField] private bool _lockCamera = false;
    //-------------------------
    private float _mousex;
    private float _mousey;



    public float rotationY = 0f;

    public bool LockCamera { get => _lockCamera; set => _lockCamera = value; }

    void Start()
    {
        
        if (_lockCursor == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    void Update()
    {
        /*
        */
        if (Input.GetKeyDown(ZoomKey))
        {
            _isZooming = !_isZooming;
        }
        if (_lockCamera == false)
        {
            _mousex = Input.GetAxis("Mouse X");
            _mousey = Input.GetAxis("Mouse Y");



            //PlayerCameraTransform.Rotate(new Vector3(-_mousey * Sensivity, 0, 0));
            PlayerTransform.Rotate(new Vector3(0, _mousex * _sensivity, 0));

            // Получаем входные данные для поворота (в данном случае, мышь)
            //float mouseX = Input.GetAxis("Mouse Y");

            // Изменяем угол поворота в зависимости от ввода
            rotationY -= _mousey * _sensivity;

            // Ограничиваем угол поворота по оси X
            rotationY = Mathf.Clamp(rotationY, -90, 90);

            // Применяем поворот к камере (или другому объекту)
            PlayerHeadTransform.localRotation = Quaternion.Euler(rotationY, 0f, 0f);

        }
        if (_isZooming)
        {
            PlayerCamera.fieldOfView = _playerCameraZoomFOV;
        }
        else
        {
            PlayerCamera.fieldOfView = _playerCameraFOV;
        }
    }
}
