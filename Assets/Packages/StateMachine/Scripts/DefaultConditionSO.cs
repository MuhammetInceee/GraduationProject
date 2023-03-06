using UnityEngine;
using UOP1.StateMachine;

[CreateAssetMenu(menuName = "State Machines/Conditions/DefaultCondition")]
public class DefaultConditionSO : StateConditionSO<DefaultCondition> { }

public class DefaultCondition : Condition
{
	//Component references

	public override void Awake(StateMachine stateMachine)
	{
	}

	protected override bool Statement()
	{
		return true;
	}
}