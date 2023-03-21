using System;
using System.Collections;
using System.Collections.Generic;
using Game.Interafaces;
using UnityEngine;

namespace Mouse.Interact
{
    public class InteractManager : MonoBehaviour
    {
        private Camera _camera;

        private void Start()
        {
            _camera = Camera.main;
        }

        private void Update()
        {
            GameObject nearestGameObject = GetNearestGameObject();
            if(nearestGameObject == null) return;


            if (Input.GetKeyDown(KeyCode.E))
            {
                if (nearestGameObject.TryGetComponent(out ICollectable collectable))
                {
                    collectable.Execute();
                }

                if (nearestGameObject.TryGetComponent(out IInteractable interactable))
                {
                    interactable.Execute();
                }
            }
        }

        private GameObject GetNearestGameObject()
        {
            GameObject result = null;
            var ray = _camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit, 3))
            {
                result = hit.transform.gameObject;
            }
            return result;
        }
    }
}
