using System;
using MainPlayer.Data;
using UnityEngine;

namespace MainPlayer.Actions
{
	
	/// <summary>
	/// Flexible StateActionSO for the StateMachine which allows to set any parameter on the Animator, in any moment of the state (OnStateEnter, OnStateExit, or each OnUpdate).
	/// </summary>
	[CreateAssetMenu(fileName = "CrouchSpeedSetterActionSO", menuName = "State Machines/Actions/SpeedSetter/CrouchSpeedSetterAction")]

	public class CrouchSpeedSetterActionSO : StateActionSO
	{
		protected override StateAction CreateAction() => new CrouchSpeedSetterAction();
	}

	public class CrouchSpeedSetterAction : StateAction
	{
		//Component references
		private PlayerMovementDataSO _playerMovementData;

		public CrouchSpeedSetterAction()
		{
		}

		private void GetReferences(StateMachine stateMachine)
		{
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
			_playerMovementData.PlayerSpeed = _playerMovementData.CrouchWalkSpeed;
		}

		public override void OnStateExit()
		{
			_playerMovementData.PlayerSpeed = _playerMovementData.WalkSpeed;
		}

		public override void OnUpdate()
		{
		}
	}

}