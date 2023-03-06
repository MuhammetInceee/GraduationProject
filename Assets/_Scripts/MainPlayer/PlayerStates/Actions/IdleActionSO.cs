using System;
using UnityEngine;
using UOP1.StateMachine;

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
	public IdleAction()
	{
	}

	public override void Awake(StateMachine stateMachine)
	{
	}

	public override void OnStateEnter()
	{
		Debug.Log("I am in Idle");
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
