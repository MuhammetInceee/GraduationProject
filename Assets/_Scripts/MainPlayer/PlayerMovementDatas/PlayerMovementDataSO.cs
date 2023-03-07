using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainPlayer.Data
{
    [CreateAssetMenu(fileName = "PlayerMovementData", menuName = "Data/PlayerMovementData")]

    public class PlayerMovementDataSO : ScriptableObject
    {
        internal float PlayerSpeed;
        
        [SerializeField] private float walkSpeed;
        public float WalkSpeed => walkSpeed;

        [SerializeField] private float crouchWalkSpeed;
        public float CrouchWalkSpeed => crouchWalkSpeed;

        [SerializeField] private float jumpForce;
        public float JumpForce => jumpForce;
    }
}
