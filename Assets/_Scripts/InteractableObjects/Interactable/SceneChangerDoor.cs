using Game.Interafaces;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.InteractableObjects
{
    public class SceneChangerDoor : MonoBehaviour, IInteractable
    {
        private readonly string[] _scenes = { "Maze", "CubePuzzle", "KitchenRoom" };
        
        public void Execute()
        {
            var targetScene = _scenes[PlayerPrefs.GetInt(PlayerPrefsLibrary.PuzzleLevel, 0)];
            
            if(targetScene == null) return;
            SceneManager.LoadScene(targetScene);
        }
    }

}
