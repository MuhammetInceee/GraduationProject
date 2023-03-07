using UnityEngine;
using UOP1.StateMachine;

namespace MainPlayer.Conditions
{
	[CreateAssetMenu(menuName = "State Machines/Conditions/JumpCondition")]

	public class JumpConditionSO : StateConditionSO<JumpCondition>
	{
	}

	public class JumpCondition : Condition
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