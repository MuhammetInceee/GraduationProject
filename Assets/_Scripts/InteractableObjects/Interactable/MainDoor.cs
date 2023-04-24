using System;
using Game.Interafaces;
using KeyInventory;
using UnityEngine;

namespace Game.InteractableObjects
{
    public class MainDoor : MonoBehaviour, IInteractable
    {
        [SerializeField] private KeyInventorySO keyInventory;
        [SerializeField] private Transform teleportTargetTr;
        
        private CharacterController _player;
        private Collider _collider;

        private void Awake()
        {
            _player = GameObject.FindWithTag("Player").GetComponent<CharacterController>();
            _collider = GetComponent<Collider>();
            keyInventory.LoadKeys();
        }
        
        public void Execute()
        {
            if(keyInventory.normalKey <= 0) return;
            keyInventory.UseKey(true);
            PlayerPrefs.SetInt(PlayerPrefsLibrary.PlayerSpawnLocation, 1);
            
            _player.enabled = false;
            _player.transform.position = teleportTargetTr.position;
            _player.enabled = true;
        }
    }
}
