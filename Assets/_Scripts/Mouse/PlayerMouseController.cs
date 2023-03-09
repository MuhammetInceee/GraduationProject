using System;
using System.Collections;
using System.Collections.Generic;
using KeyBinds;
using UnityEngine;

namespace Mouse.PlayerInput
{
    public class PlayerMouseController : MonoBehaviour
    {
        #region SerializeField Parameters

        

        #endregion
        
        
        #region Private Parameters

        

        #endregion
        
        
        #region Public Parameters

        

        #endregion
        
        [SerializeField] private float sensitivity = 100f;
        [SerializeField] private Transform playerBody;
        private float _xRotation = 0f;
        private Camera _playerCamera;
        private KeyBindsSO _keyBinds;
        
        
        
        
        
        [Header("Zoom Parameters")]
        [SerializeField] private float timeToZoom = 0.3f;
        [SerializeField] private float zoomFOV = 30f;
        private float _defaultFOV;
        private Coroutine _zoomRoutine;
        private float _defaultYPos = 0;

        



        private void Start()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            _playerCamera = GetComponent<Camera>();
            _keyBinds = Resources.Load<KeyBindsSO>("KeyBinds/KeyBinds");
            
            _defaultYPos = _playerCamera.transform.localPosition.y;
            _defaultFOV = _playerCamera.fieldOfView;
        }

        void Update()
        {
            MouseController();
            HandleZoom();
        }

        private void MouseController()
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -90f, 55f);

            transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }

        #region CameraZoom

        private void HandleZoom()
        {
            foreach (KeyCode zoomKey in _keyBinds.ZoomKeys)
            {
                if (Input.GetKeyDown(zoomKey))
                {
                    Zoom(true);
                }
                
                if (Input.GetKeyUp(zoomKey))
                {
                    Zoom(false);
                }
            }
        }

        private void Zoom(bool zooming)
        {
            if (_zoomRoutine != null)
            {
                StopCoroutine(_zoomRoutine);
                _zoomRoutine = null;
            }

            _zoomRoutine = StartCoroutine(ToggleZoom(zooming));
        }
        
        private IEnumerator ToggleZoom(bool isEnter)
        {
            float targetFOV = isEnter ? zoomFOV : _defaultFOV;
            float startingFOV = _playerCamera.fieldOfView;
            float timeElapsed = 0;

            while (timeElapsed < timeToZoom)
            {
                _playerCamera.fieldOfView = Mathf.Lerp(startingFOV, targetFOV, timeElapsed / timeToZoom);
                timeElapsed += Time.deltaTime;
                yield return null;
            }

            _playerCamera.fieldOfView = targetFOV;
            _zoomRoutine = null;
        }

        #endregion
    }
}
