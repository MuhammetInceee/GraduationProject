using System.Collections;
using System.Collections.Generic;
using Game.InteractableObjects;
using UnityEngine;

namespace Game.Managers
{
    public class CubePuzzleManager : MonoBehaviour
    {
        internal bool CanPlay = true;


        [SerializeField] private GameObject key;
        [SerializeField] private PuzzleCubes[] allCubes;


        public void CheckAndFinishGame()
        {
            if (IsLevelComplete())
            {
                CanPlay = false;
                key.SetActive(true);
            }
        }

        private bool IsLevelComplete()
        {
            for (int i = 0; i < allCubes.Length; i++)
            {
                if (allCubes[i].transform.position != allCubes[i].targetPos)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
