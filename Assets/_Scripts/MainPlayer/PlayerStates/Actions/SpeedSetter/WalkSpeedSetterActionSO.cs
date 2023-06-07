using System;
using MainPlayer.Data;
using UnityEngine;

namespace MainPlayer.Actions
{
	
	/// <summary>
	/// Flexible StateActionSO for the StateMachine which allows to set any parameter on the Animator, in any moment of the state (OnStateEnter, OnStateExit, or each OnUpdate).
	/// </summary>
	[CreateAssetMenu(fileName = "WalkSpeedSetterActionSO", menuName = "State Machines/Actions/SpeedSetter/WalkSpeedSetterAction")]

	public class WalkSpeedSetterActionSO : StateActionSO
	{
		protected override StateAction CreateAction() => new WalkSpeedSetterAction();
	}

	public class WalkSpeedSetterAction : StateAction
	{
		//Component references
		private PlayerMovementDataSO _playerMovementData;

		public WalkSpeedSetterAction()
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
			_playerMovementData.PlayerSpeed = _playerMovementData.WalkSpeed;
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