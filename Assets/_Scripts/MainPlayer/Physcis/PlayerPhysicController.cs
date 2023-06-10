using System;
using System.Collections;
using System.Collections.Generic;
using MainPlayer.Conditions;
using MainPlayer.Data;
using UnityEngine;

public class PlayerPhysicController : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTr;
    [SerializeField] private float groundDistance;
    [SerializeField] private LayerMask groundLayer;
    
    
    private CharacterController _controller;
    private Conditions _conditions;
    private PlayerPhysicControllerSO _playerPhysicData;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
        _conditions = GetComponent<Conditions>();
        _playerPhysicData = Resources.Load<PlayerPhysicControllerSO>("MainPlayer/PlayerPhysicControllerSO");
    }


    private void Update()
    {
        IsGroundCheck();
        Gravity();
    }

    private void Gravity()
    {
        if (_conditions.isGrounded && _playerPhysicData.PhysicVelocity.y < 0)
        {
            _playerPhysicData.PhysicVelocity.y = -9.81f;
        }

        _playerPhysicData.PhysicVelocity.y += _playerPhysicData.Gravity * Time.deltaTime;

        _controller.Move(_playerPhysicData.PhysicVelocity * Time.deltaTime);
    }

    private void IsGroundCheck()
    {
        if (!_conditions.CanCheck) return;
        _conditions.isGrounded = Physics.CheckSphere(groundCheckTr.position, groundDistance, groundLayer);
    }
    
}
