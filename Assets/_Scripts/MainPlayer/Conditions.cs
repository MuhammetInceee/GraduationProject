using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainPlayer.Conditions
{
    public class Conditions : MonoBehaviour
    {
        private bool _settingsFocus;
        [SerializeField] private RectTransform settings;
        
        internal bool CanCheck = true;
        internal bool canGetSettings;

        public bool isGrounded;
        public bool isInInteraction;

        public IEnumerator Jump()
        {
            CanCheck = false;
            isGrounded = false;
            yield return new WaitForSeconds(1.2f);
            isGrounded = true;
        }

        private void Update()
        {
            if (!Input.GetKeyDown(KeyCode.Escape)) return;
            if (canGetSettings)
            {
                Application.Quit();
            }
            else
            {
                if (_settingsFocus)
                {
                    Time.timeScale = 1;

                    settings.DOAnchorPosY(1200, 0.3f)
                        .SetEase(Ease.OutSine)
                        .OnComplete(() =>
                        {
                            Cursor.visible = false;
                            Cursor.lockState = CursorLockMode.Locked;
                        });
                }
                else
                {
                    settings.DOAnchorPosY(0, 0.3f)
                        .SetEase(Ease.InSine)
                        .OnComplete(() =>
                        {
                            Time.timeScale = 0;
                            Cursor.visible = true;
                            Cursor.lockState = CursorLockMode.None;
                        });
                }
                _settingsFocus = !_settingsFocus;
            }
        }

        public void Quit()
        {
            Application.Quit();
        }

        public void MainMenu()
        {
            SceneManager.LoadScene("MainMenu");
            Time.timeScale = 1;
        }
    }
}