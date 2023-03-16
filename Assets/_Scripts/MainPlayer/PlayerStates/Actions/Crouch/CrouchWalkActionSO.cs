using System;
using MainPlayer.Data;
using UnityEngine;
using UOP1.StateMachine;

namespace MainPlayer.Actions
{
    /// <summary>
    /// Flexible StateActionSO for the StateMachine which allows to set any parameter on the Animator, in any moment of the state (OnStateEnter, OnStateExit, or each OnUpdate).
    /// </summary>
    [CreateAssetMenu(fileName = "CrouchWalkActionSO1", menuName = "State Machines/Actions/CrouchWalkAction")]
    public class CrouchWalkActionSO : StateActionSO
    {
        protected override StateAction CreateAction() => new CrouchWalkAction();
    }

    public class CrouchWalkAction : StateAction
    {
        // Animator Hash Codes
        private static readonly int WalkForward = Animator.StringToHash("C_WalkForward");
        private static readonly int WalkBackward = Animator.StringToHash("C_WalkBackward");
        private static readonly int SideLeftWalk = Animator.StringToHash("C_SideLeftWalk");
        private static readonly int SideRightWalk = Animator.StringToHash("C_SideRightWalk");
        private static readonly int CrouchIdle = Animator.StringToHash("Crouch");
        
        //Component references
        private Transform _transform;
        private PlayerMovementDataSO _playerMovementData;
        private Animator _animator;
        private CharacterController _controller;

        public CrouchWalkAction()
        {
        }

        private void GetReferences(StateMachine stateMachine)
        {
            _transform = stateMachine.GetComponent<Transform>();
            _animator = stateMachine.GetComponent<Animator>();
            _controller = stateMachine.GetComponent<CharacterController>();
        }

        private void DataReadFromResource()
        {
            _playerMovementData = Resources.Load<PlayerMovementDataSO>("MainPlayer/PlayerMovementData");
        }

        public override void Awake(StateMachine stateMachine)
        {
            GetReferences(stateMachine);
            DataReadFromResource();
        }

        public override void OnStateEnter()
        {
        }

        public override void OnStateExit()
        {
            _animator.SetBool(WalkForward, false);
            _animator.SetBool(WalkBackward, false);
            _animator.SetBool(SideLeftWalk, false);
            _animator.SetBool(SideRightWalk, false);
            _animator.SetBool(CrouchIdle, false);
        }

        private void SetParameter()
        {
        }

        public override void OnUpdate()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            
            PlayerMovement(horizontalInput, verticalInput);
            PlayerAnimationController(horizontalInput, verticalInput);
        }

        private void PlayerMovement(float horizontalInput, float verticalInput)
        {
            Vector3 move = _transform.right * horizontalInput + _transform.forward * verticalInput;
            _controller.Move(move * (_playerMovementData.PlayerSpeed * Time.deltaTime));
        }

        private void PlayerAnimationController(float horizontalInput, float verticalInput)
        {
            bool isWalkingForward = verticalInput > 0;
            bool isWalkingBackward = verticalInput < 0;
            bool isSideWalkingLeft = horizontalInput < 0 && verticalInput == 0;
            bool isSideWalkingRight = horizontalInput > 0 && verticalInput == 0;
            bool isIdle = verticalInput == 0 && horizontalInput == 0; 

            _animator.SetBool(CrouchIdle, isIdle);
            _animator.SetBool(WalkForward, isWalkingForward);
            _animator.SetBool(WalkBackward, isWalkingBackward);
            _animator.SetBool(SideLeftWalk, isSideWalkingLeft);
            _animator.SetBool(SideRightWalk, isSideWalkingRight);
        }
    }
}