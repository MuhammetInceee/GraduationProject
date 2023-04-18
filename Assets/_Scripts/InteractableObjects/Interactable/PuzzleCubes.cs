using System.Collections;
using System.Collections.Generic;
using Game.Interafaces;
using UnityEngine;

namespace Game.InteractableObjects
{
    public class PuzzleCubes : MonoBehaviour, IInteractable
    {
        public void Execute()
        {
            CheckNeighbour(Vector3.back);
        }

        private bool CheckNeighbour(Vector3 position)
        {
            RaycastHit hit;

            if (Physics.Raycast(transform.position, position, out hit, 1))
            {
                print(hit.collider.gameObject.name);
                return true;
            }
            else
            {
                
            }

            return false;
        }
        
    }
}
