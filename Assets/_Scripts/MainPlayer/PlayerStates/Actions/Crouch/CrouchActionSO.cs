using System;
using UnityEngine;
using UOP1.StateMachine;

namespace MainPlayer.Actions
{
	
	/// <summary>
	/// Flexible StateActionSO for the StateMachine which allows to set any parameter on the Animator, in any moment of the state (OnStateEnter, OnStateExit, or each OnUpdate).
	/// </summary>
	[CreateAssetMenu(fileName = "CrouchActionSO", menuName = "State Machines/Actions/CrouchAction")]

	public class CrouchActionSO : StateActionSO
	{
		protected override StateAction CreateAction() => new CrouchAction();
	}

	public class CrouchAction : StateAction
	{
		//Component references
		private Transform _transform;
		public CrouchAction()
		{
		}

		public override void Awake(StateMachine stateMachine)
		{
			_transform = stateMachine.GetComponent<Transform>();
		}

		public override void OnStateEnter()
		{
			_transform.localScale = new Vector3(1, 0.7f, 1f);
		}

		public override void OnStateExit()
		{
			_transform.localScale = Vector3.one;
		}

		private void SetParameter()
		{
		}

		public override void OnUpdate()
		{
		}
	}

}