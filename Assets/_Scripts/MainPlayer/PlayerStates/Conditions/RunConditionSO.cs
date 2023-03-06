using UnityEngine;
using UOP1.StateMachine;

[CreateAssetMenu(menuName = "State Machines/Conditions/RunCondition")]
public class RunConditionSO : StateConditionSO<RunCondition> { }

public class RunCondition : Condition
{
	//Component references

	public override void Awake(StateMachine stateMachine)
	{
	}

	protected override bool Statement()
	{
		if (Input.GetKey(KeyCode.LeftShift)) return true;
		return false;
	}
}