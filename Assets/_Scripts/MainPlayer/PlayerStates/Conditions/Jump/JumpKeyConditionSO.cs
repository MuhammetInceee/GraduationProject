using KeyBinds;
using UnityEngine;
using UOP1.StateMachine;

namespace MainPlayer.Conditions
{
	[CreateAssetMenu(menuName = "State Machines/Conditions/JumpKeyCondition")]

	public class JumpKeyConditionSO : StateConditionSO<JumpKeyCondition>
	{
	}

	public class JumpKeyCondition : Condition
	{
		//Component references
		private KeyBindsSO _keyBinds;

		public override void Awake(StateMachine stateMachine)
		{
			_keyBinds = Resources.Load<KeyBindsSO>("KeyBinds/KeyBinds");
		}

		protected override bool Statement()
		{
			foreach (KeyCode jumpKey in _keyBinds.jumpKeys)
			{
				if (Input.GetKeyDown(jumpKey))
				{
					return true;
				}

				return false;
			}

			return false;
		}
	}
}