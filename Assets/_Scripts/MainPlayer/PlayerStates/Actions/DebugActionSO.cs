using System;
using MainPlayer.Data;
using UnityEngine;
using UOP1.StateMachine;

namespace MainPlayer.Actions.Debugger
{
	
	/// <summary>
	/// Flexible StateActionSO for the StateMachine which allows to set any parameter on the Animator, in any moment of the state (OnStateEnter, OnStateExit, or each OnUpdate).
	/// </summary>
	[CreateAssetMenu(fileName = "DebugActionSO", menuName = "State Machines/Actions/DebugAction")]

	public class DebugActionSO : StateActionSO
	{
		protected override StateAction CreateAction() => new DebugAction();
	}

	public class DebugAction : StateAction
	{
		//Component references

		public DebugAction()
		{
		}

		private void GetReferences(StateMachine stateMachine)
		{
		}

		private void DataReadFromResource()
		{
		}

		public override void Awake(StateMachine stateMachine)
		{
			Debug.Log("Awake");
		}

		public override void OnStateEnter()
		{
			Debug.Log("OnState Enter");
		}

		public override void OnStateExit()
		{
			Debug.Log("OnState Exit");
		}

		private void SetParameter()
		{
		}

		public override void OnUpdate()
		{
			Debug.Log("Update");
		}
	}

}