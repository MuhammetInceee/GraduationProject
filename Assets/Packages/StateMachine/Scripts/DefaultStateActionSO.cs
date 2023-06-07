using System;
using UnityEngine;

/// <summary>
/// Flexible StateActionSO for the StateMachine which allows to set any parameter on the Animator, in any moment of the state (OnStateEnter, OnStateExit, or each OnUpdate).
/// </summary>
[CreateAssetMenu(fileName = "DefaultAction", menuName = "State Machines/Actions/DefaultAction")]
public class DefaultStateActionSO : StateActionSO
{
	protected override StateAction CreateAction() => new DefaultStateAction();
}

public class DefaultStateAction : StateAction
{
	//Component references
	public DefaultStateAction()
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
