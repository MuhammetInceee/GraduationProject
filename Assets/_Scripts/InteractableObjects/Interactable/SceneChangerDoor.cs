using Game.Interafaces;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.InteractableObjects
{
    public class SceneChangerDoor : MonoBehaviour, IInteractable
    {
        public SceneNameEnum sceneName;

        public void Execute()
        {
            SceneManager.LoadScene(sceneName.ToString());
        }
    }

}
