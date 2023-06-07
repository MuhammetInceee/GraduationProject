using KeyBinds;
using UnityEngine;

namespace MainPlayer.Conditions
{
	[CreateAssetMenu(menuName = "State Machines/Conditions/KeyConditions/CrouchKeyCondition")]

	public class CrouchKeyConditionSO : StateConditionSO<CrouchKeyCondition>
	{
	}

	public class CrouchKeyCondition : Condition
	{
		//Component references
		private KeyBindsSO _keyBinds;

		public override void Awake(StateMachine stateMachine)
		{
			_keyBinds = Resources.Load<KeyBindsSO>("KeyBinds/KeyBinds");
		}

		protected override bool Statement()
		{
			foreach (KeyCode crouchKey in _keyBinds.CrouchKeys)
			{
				if (Input.GetKey(crouchKey))
				{
					return true;
				}

				return false;
			}

			return false;
		}
	}
}