using System;
using MainPlayer.Data;
using UnityEngine;
using UOP1.StateMachine;

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
		//Component references
		
		private Rigidbody _rb;
		private PlayerMovementDataSO _playerMovementData;
		private Conditions.Conditions _conditions;
		
		public JumpAction()
		{
		}

		private void GetReferences(StateMachine stateMachine)
		{
			_rb = stateMachine.GetComponent<Rigidbody>();
			_conditions = stateMachine.GetComponent<Conditions.Conditions>();
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
			_conditions.StartCoroutine(_conditions.Jump());
			_rb.AddForce(Vector3.up * _playerMovementData.JumpForce);
		}

		public override void OnStateExit()
		{
		}

		private void SetParameter()
		{
		}

		public override void OnUpdate()
		{
		}
	}

}