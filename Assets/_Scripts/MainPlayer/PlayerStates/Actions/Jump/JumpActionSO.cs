using System;
using MainPlayer.Data;
using UnityEngine;

namespace MainPlayer.Actions
{
	
	/// <summary>
	/// Flexible StateActionSO for the StateMachine which allows to set any parameter on the Animator, in any moment of the state (OnStateEnter, OnStateExit, or each OnUpdate).
	/// </summary>
	[CreateAssetMenu(fileName = "JumpActionSO", menuName = "State Machines/Actions/JumpAction")]

	public class JumpActionSO : StateActionSO
	{
		protected override StateAction CreateAction() => new JumpAction();
	}

	public class JumpAction : StateAction
	{
		private static readonly int Jump = Animator.StringToHash("Jump");
		//Component references

		private Animator _animator;
		private Conditions.Conditions _conditions;
		private PlayerMovementDataSO _playerMovementData;
		private PlayerPhysicControllerSO _playerPhysicController;

		public JumpAction()
		{
		}

		private void GetReferences(StateMachine stateMachine)
		{
			_conditions = stateMachine.GetComponent<Conditions.Conditions>();
			_animator = stateMachine.GetComponent<Animator>();
		}

		private void DataReadFromResource()
		{
			_playerMovementData = Resources.Load<PlayerMovementDataSO>("MainPlayer/PlayerMovementData");
			_playerPhysicController = Resources.Load<PlayerPhysicControllerSO>("MainPlayer/PlayerPhysicControllerSO");
		}

		public override void Awake(StateMachine stateMachine)
		{
			GetReferences(stateMachine);
			DataReadFromResource();
		}

		public override void OnStateEnter()
		{ 
			_conditions.StartCoroutine(_conditions.Jump());
			_playerPhysicController.PhysicVelocity.y =
				Mathf.Sqrt(_playerMovementData.JumpHeight * -2 * _playerPhysicController.Gravity);
			_animator.SetBool(Jump, true);
		}

		public override void OnStateExit()
		{
			_animator.SetBool(Jump, false);
		}

		private void SetParameter()
		{
		}

		public override void OnUpdate()
		{
		}
	}

}