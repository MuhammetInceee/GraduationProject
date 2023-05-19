using Game.Interafaces;
using KeyInventory;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.InteractableObjects
{
    public class StoryKey : MonoBehaviour, ICollectable
    {
        private int _buy;

        [SerializeField] private KeyInventorySO keyInventory;
        public SceneNameEnum sceneName;


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
            keyInventory.AddKey(false);
            gameObject.SetActive(false);
            SceneManager.LoadScene(sceneName.ToString());
            PlayerPrefs.SetInt(PlayerPrefsLibrary.PuzzleLevel, PlayerPrefs.GetInt(PlayerPrefsLibrary.PuzzleLevel, 0) + 1);
        }
    }
}
