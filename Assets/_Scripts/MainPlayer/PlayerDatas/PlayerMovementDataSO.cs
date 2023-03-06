using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "PlayerMovementData", menuName = "Data/PlayerMovementData")]
public class PlayerMovementDataSO : ScriptableObject
{
    [SerializeField] private float walkSpeed;
    public float WalkSpeed => walkSpeed;
}
