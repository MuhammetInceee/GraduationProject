using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.MainMenu
{
    public class MainMenuUI : MonoBehaviour
    {
        public void PlayButton()
        {
            SceneManager.LoadScene("House");
        }

        public void ExitButton()
        {
            Application.Quit();
        }
    }
}
