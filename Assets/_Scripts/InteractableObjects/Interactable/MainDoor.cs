using System;
using Game.Interafaces;
using KeyInventory;
using UnityEngine;

namespace Game.InteractableObjects
{
    public class MainDoor : MonoBehaviour, IInteractable
    {
        [SerializeField] private KeyInventorySO keyInventory;
        
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
            _collider.enabled = false;
            _player.Move(transform.right * -5);
            _collider.enabled = true;
        }
    }
}
