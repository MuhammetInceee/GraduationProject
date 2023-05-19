using System;
using Game.Interafaces;
using KeyInventory;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.InteractableObjects
{
    public class MainDoor : MonoBehaviour, IInteractable
    {
        [SerializeField] private KeyInventorySO keyInventory;
        public SceneNameEnum sceneName;

        private void Awake()
        {
            keyInventory.LoadKeys();
        }
        
        public void Execute()
        {
            if(keyInventory.normalKey <= 0) return;
            keyInventory.UseKey(true);
            PlayerPrefs.SetInt(PlayerPrefsLibrary.PlayerSpawnLocation, 1);
            SceneManager.LoadScene(sceneName.ToString());
        }
        
    }
}
