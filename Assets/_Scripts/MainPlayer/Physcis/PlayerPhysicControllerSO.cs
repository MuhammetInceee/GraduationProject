using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerPhysicControllerSO", menuName = "Physic/PlayerPhysicData")]
public class PlayerPhysicControllerSO : ScriptableObject
{
    internal Vector3 PhysicVelocity;
    
    public float Gravity = -9.81f;
}
