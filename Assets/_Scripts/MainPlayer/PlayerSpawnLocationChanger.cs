using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MainPlayer.Data
{
    public class PlayerSpawnLocationChanger : MonoBehaviour
    {
        [SerializeField] private SceneNameEnum sceneName;


        private void Awake()
        {
            if (PlayerPrefs.GetInt(PlayerPrefsLibrary.PlayerSpawnLocation) == 1)
            {
                SceneManager.LoadScene(sceneName.ToString());
            }
        }
    }
}
