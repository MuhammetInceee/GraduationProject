using System;
using Game.Interafaces;
using KeyInventory;
using UnityEngine;

namespace Game.InteractableObjects
{
    public class Keys : MonoBehaviour, ICollectable
    {
        private int _buy;

        [SerializeField] private KeyInventorySO keyInventory;

        private void Awake()
        {
            CheckBought();
        }

        private void CheckBought()
        {
            if (!PlayerPrefs.HasKey("Key" + gameObject.GetInstanceID())) return;
            gameObject.SetActive(false);
        }

        public void Execute()
        {
            PlayerPrefs.SetInt("Key" + gameObject.GetInstanceID(), 1);
            keyInventory.AddKey(true);
            gameObject.SetActive(false);
        }
    }
}
