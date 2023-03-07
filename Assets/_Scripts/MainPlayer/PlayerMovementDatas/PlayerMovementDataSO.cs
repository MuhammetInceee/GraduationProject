using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MainPlayer.Data
{
    [CreateAssetMenu(fileName = "PlayerMovementData", menuName = "Data/PlayerMovementData")]

    public class PlayerMovementDataSO : ScriptableObject
    {
        [SerializeField] private float walkSpeed;
        public float WalkSpeed => walkSpeed;

        [SerializeField] private float jumpForce;
        public float JumpForce => jumpForce;
    }
}
