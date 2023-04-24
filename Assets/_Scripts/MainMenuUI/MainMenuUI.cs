using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI.MainMenu
{
    public class MainMenuUI : MonoBehaviour
    {
        public void PlayButton(GameObject obj)
        {
            obj.transform.localScale = Vector3.one * 0.9f;

            obj.transform.DOScale(Vector3.one, 0.3f)
                .OnComplete(() =>
                {
                    SceneManager.LoadScene("House");
                });
        }

        public void ExitButton(GameObject obj)
        {
            obj.transform.localScale = Vector3.one * 0.9f;

            obj.transform.DOScale(Vector3.one, 0.3f)
                .OnComplete(Application.Quit);
            
        }
    }
}
