using System;
using System.Collections;
using System.Collections.Generic;
using Game.Interafaces;
using UnityEngine;
using DG.Tweening;
using Game.Managers;

namespace Game.InteractableObjects
{
    public class PuzzleCubes : MonoBehaviour, IInteractable
    {
        #region CustomVectorVariables

        private const float Distance = 0.8f;
        
        private static readonly Vector3 BackVector = new Vector3(0, 0, -Distance);
        private static readonly Vector3 ForwardVector = new Vector3(0, 0, Distance);
        private static readonly Vector3 UpVector = new Vector3(0, Distance, 0);
        private static readonly Vector3 DownVector = new Vector3(0, -Distance, 0);

        #endregion
        
        private readonly Vector3[] _calculateVectors = new[] { BackVector, ForwardVector, UpVector, DownVector };
        private CubePuzzleManager _puzzleManager;
        private bool _canMove = true;
        

        public Vector3 targetPos;

        private void Awake()
        {
            _puzzleManager = transform.GetComponentInParent<CubePuzzleManager>();
        }

        public void Execute()
        {
            if (!_canMove || !_puzzleManager.CanPlay) return;

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
                return true;
            }

            _canMove = false;
            transform.DOMove(position, 0.5f)
                .SetRelative()
                .OnComplete(() =>
                {
                    _canMove = true;
                    _puzzleManager.CheckAndFinishGame();
                });
            return false;
        }
    }
}