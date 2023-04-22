using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainPlayer.Data
{
    public class PlayerSpawnLocationChanger : MonoBehaviour
    {
        [SerializeField] private GameObject player;

        [SerializeField] private Transform[] locations;


        private void Awake()
        {
            player.GetComponent<CharacterController>().enabled = false;

            player.transform.position = locations[PlayerPrefs.GetInt(PlayerPrefsLibrary.PlayerSpawnLocation, 0)].position;
            
            player.GetComponent<CharacterController>().enabled = true;
        }
    }
}
