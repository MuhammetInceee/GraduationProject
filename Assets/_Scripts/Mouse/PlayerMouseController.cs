using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Mouse.PlayerInput
{
    public class PlayerMouseController : MonoBehaviour
    {
        [SerializeField] private float sensitivity = 100f;
        [SerializeField] private Transform playerBody;

        private float _xRotation = 0f;

        private void Start()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        void Update()
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

            _xRotation -= mouseY;
            _xRotation = Mathf.Clamp(_xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }

    }
}
