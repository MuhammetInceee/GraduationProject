using System;
using UnityEngine;

namespace MainPlayer.Actions
{
	
	/// <summary>
	/// Flexible StateActionSO for the StateMachine which allows to set any parameter on the Animator, in any moment of the state (OnStateEnter, OnStateExit, or each OnUpdate).
	/// </summary>
	[CreateAssetMenu(fileName = "IdleActionSO", menuName = "State Machines/Actions/IdleAction")]

	public class IdleActionSO : StateActionSO
	{
		protected override StateAction CreateAction() => new IdleAction();
	}

	public class IdleAction : StateAction
	{
		//Component references
		private Animator _animator;
		private static readonly int GoIdle = Animator.StringToHash("GoIdle");

		public IdleAction()
		{
		}

		public override void Awake(StateMachine stateMachine)
		{
			_animator = stateMachine.GetComponent<Animator>();
		}

		public override void OnStateEnter()
		{
			_animator.SetBool(GoIdle, true);
		}

		public override void OnStateExit()
		{
			_animator.SetBool(GoIdle, false);
		}

		private void SetParameter()
		{
			
		}

		public override void OnUpdate()
		{
		}
	}

}