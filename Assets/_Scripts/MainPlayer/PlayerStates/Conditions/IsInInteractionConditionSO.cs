using UnityEngine;
using UOP1.StateMachine;

namespace MainPlayer.Conditions
{
	[CreateAssetMenu(fileName = "IsInInteractionConditionSO" ,menuName = "State Machines/Conditions/IsInInteractionCondition")]

	public class IsInInteractionConditionSO : StateConditionSO<IsInInteractionCondition>
	{
	}

	public class IsInInteractionCondition : Condition
	{
		//Component references
		private Conditions _conditions;

		public override void Awake(StateMachine stateMachine)
		{
			_conditions = stateMachine.GetComponent<Conditions>();
		}

		protected override bool Statement()
		{
			return _conditions.isInInteraction;
		}
	}
}