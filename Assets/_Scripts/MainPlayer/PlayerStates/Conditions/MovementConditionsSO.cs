using UnityEngine;

namespace MainPlayer.Conditions
{
	[CreateAssetMenu(menuName = "State Machines/Conditions/MovementConditions")]

	public class MovementConditionsSO : StateConditionSO<MovementConditions>
	{
	}

	public class MovementConditions : Condition
	{
		//Component references

		public override void Awake(StateMachine stateMachine)
		{
		}

		protected override bool Statement()
		{
			if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) ||
			    Input.GetKey(KeyCode.D)) return true;
			return false;
		}
	}
}