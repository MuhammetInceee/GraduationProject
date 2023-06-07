using UnityEngine;

namespace MainPlayer.Conditions
{
	[CreateAssetMenu(menuName = "State Machines/Conditions/JumpCondition")]

	public class IsGroundConditionSO : StateConditionSO<IsGroundCondition>
	{
	}

	public class IsGroundCondition : Condition
	{
		//Component references
		private Conditions _conditions;

		public override void Awake(StateMachine stateMachine)
		{
			_conditions = stateMachine.GetComponent<Conditions>();
		}

		protected override bool Statement()
		{
			return _conditions.isGrounded;
		}
	}
}