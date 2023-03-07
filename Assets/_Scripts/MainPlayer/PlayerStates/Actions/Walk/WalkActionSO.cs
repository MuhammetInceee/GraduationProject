using System;
using MainPlayer.Data;
using UnityEngine;
using UOP1.StateMachine;

namespace MainPlayer.Actions
{
	
	/// <summary>
	/// Flexible StateActionSO for the StateMachine which allows to set any parameter on the Animator, in any moment of the state (OnStateEnter, OnStateExit, or each OnUpdate).
	/// </summary>
	[CreateAssetMenu(fileName = "WalkActionSO", menuName = "State Machines/Actions/WalkAction")]

	public class WalkActionSO : StateActionSO
	{
		protected override StateAction CreateAction() => new WalkAction();
	}

	public class WalkAction : StateAction
	{
		//Component references
		private Rigidbody _rb;
		private Transform _transform;
		private PlayerMovementDataSO _playerMovementData;

		public WalkAction()
		{
		}

		private void GetReferences(StateMachine stateMachine)
		{
			_transform = stateMachine.GetComponent<Transform>();
			_rb = stateMachine.GetComponent<Rigidbody>();
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
		}

		private void SetParameter()
		{
		}

		public override void OnUpdate()
		{
			float horizontal = Input.GetAxis("Horizontal");
			float vertical = Input.GetAxis("Vertical");

			Vector3 move = _transform.right * horizontal + _transform.forward * vertical;

			_rb.MovePosition(_rb.position + move * (_playerMovementData.WalkSpeed * Time.deltaTime));
		}
	}

}