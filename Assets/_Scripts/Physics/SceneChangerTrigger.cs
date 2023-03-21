using UnityEngine;
using UnityEngine.SceneManagement;

namespace Game.Physics.Trigger
{
    public class SceneChangerTrigger : MonoBehaviour
    {
        public SceneNames sceneName;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                SceneManager.LoadScene(sceneName.ToString());
            }
        }
    }
    
    public enum SceneNames
    {
        MainMenu,
        House,
        Maze
    }

}
