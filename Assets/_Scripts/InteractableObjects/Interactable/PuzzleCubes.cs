using System.Collections;
using System.Collections.Generic;
using Game.Interafaces;
using UnityEngine;
using DG.Tweening;

namespace Game.InteractableObjects
{
    public class PuzzleCubes : MonoBehaviour, IInteractable
    {
        private readonly Vector3[] _calculateVectors = new[] { Vector3.back, Vector3.forward, Vector3.up, Vector3.down };
        private bool _canMove = true;

        public void Execute()
        {
            if (!_canMove) return;

            for (int i = 0; i < _calculateVectors.Length; i++)
            {
                if (!CheckNeighbour(_calculateVectors[i]))
                {
                    break;
                }
            }
        }

        private bool CheckNeighbour(Vector3 position)
        {
            if (Physics.Raycast(transform.position, position, out RaycastHit hit, 1))
            {
                print(hit.collider.gameObject.name);
                return true;
            }

            _canMove = false;
            transform.DOMove(position, 0.5f)
                .SetRelative()
                .OnComplete(() =>
                {
                    // Puzzle Complete or Not 
                    _canMove = true;
                });
            return false;
        }
    }
}