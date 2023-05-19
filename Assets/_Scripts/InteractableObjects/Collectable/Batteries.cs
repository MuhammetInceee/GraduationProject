using System;
using System.Collections;
using System.Collections.Generic;
using Game.Interafaces;
using MainPlayer.FlashLight;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.InteractableObjects
{
    public class Batteries : MonoBehaviour,ICollectable
    {
        [SerializeField] private FlashLightSO flashLightSO;
        public void Execute()
        {
            flashLightSO.AddBattery();
            Destroy(gameObject);
        }
    }
}
