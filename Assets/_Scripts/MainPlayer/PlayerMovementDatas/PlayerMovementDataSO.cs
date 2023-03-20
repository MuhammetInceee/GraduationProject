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

        [SerializeField] private float walkSpeed;
        public float WalkSpeed => walkSpeed;

        [SerializeField] private float crouchWalkSpeed;
        public float CrouchWalkSpeed => crouchWalkSpeed;

        [FormerlySerializedAs("jumpForce")] [SerializeField] private float jumpHeight;
        public float JumpHeight => jumpHeight;
    }
}
