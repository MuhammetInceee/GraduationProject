using System;
using MainPlayer.Data;
using UnityEngine;

namespace MainPlayer.Actions.Debugger
{
	
	/// <summary>
	/// Flexible StateActionSO for the StateMachine which allows to set any parameter on the Animator, in any moment of the state (OnStateEnter, OnStateExit, or each OnUpdate).
	/// </summary>
	[CreateAssetMenu(fileName = "InteractionActionSO", menuName = "State Machines/Actions/InteractionAction")]

	public class InteractionActionSO : StateActionSO
	{
		protected override StateAction CreateAction() => new InteractionAction();
	}

	public class InteractionAction : StateAction
	{
		//Component references

		public InteractionAction()
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
		}
	}

}