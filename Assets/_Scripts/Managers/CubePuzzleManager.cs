using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
            if (!IsLevelComplete()) return;
            CanPlay = false;
            key.SetActive(true);
        }

        private bool IsLevelComplete()
        {
            return allCubes.All(t => t.transform.localPosition == t.targetPos);
        }
    }
}
