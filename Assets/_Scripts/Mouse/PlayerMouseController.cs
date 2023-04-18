using System;
using System.Collections;
using System.Collections.Generic;
using KeyBinds;
using MainPlayer.Data;
using UnityEngine;
using UnityEngine.Serialization;

namespace Mouse.PlayerInput
{
    public class PlayerMouseController : MonoBehaviour
    {
        private bool canFallow = true;
        private PlayerMovementDataSO _playerMovementData;
        
        [SerializeField] private Transform playerBody;
        private float _xRotationCamera = 0f;
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
            ResourceReadData();
            GetReferences();
            InitVariables();
        }

        void Update()
        {
            MouseController();
            HandleZoom();
        }

        private void MouseController()
        {
            float mouseX = Input.GetAxis("Mouse X") * _playerMovementData.MouseSensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * _playerMovementData.MouseSensitivity * Time.deltaTime;

            _xRotationCamera -= mouseY;
            _xRotationCamera = Mathf.Clamp(_xRotationCamera, 0, 140);
            transform.localRotation = Quaternion.Euler(_xRotationCamera, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }

        #region Initializers

        private void ResourceReadData()
        {
            _keyBinds = Resources.Load<KeyBindsSO>("KeyBinds/KeyBinds");
            _playerMovementData = Resources.Load<PlayerMovementDataSO>("MainPlayer/PlayerMovementData");
        }

        private void GetReferences()
        {
            _playerCamera = GetComponent<Camera>();
        }

        private void InitVariables()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            
            _defaultYPos = _playerCamera.transform.localPosition.y;
            _defaultFOV = _playerCamera.fieldOfView;
        }

        #endregion

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
