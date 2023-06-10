using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace MainPlayer.Data
{
    [CreateAssetMenu(fileName = "PlayerMovementData", menuName = "MainPlayer/Data/PlayerMovementData")]

    public class PlayerMovementDataSO : ScriptableObject
    {
        internal float PlayerSpeed;
        
        [Header("Movement Parameters")]
        [SerializeField] private float walkSpeed;
        public float WalkSpeed => walkSpeed;

        [SerializeField] private float crouchWalkSpeed;
        public float CrouchWalkSpeed => crouchWalkSpeed;

        [SerializeField] private float jumpHeight;
        public float JumpHeight => jumpHeight;
        
        [Header("Mouse Parameters")]

        [SerializeField] private float mouseSensitivity;
        public float MouseSensitivity
        {
            get => mouseSensitivity;
            set => mouseSensitivity = value;
        }
    }
}
