using System;
using UnityEngine;

namespace MainPlayer.Actions
{
	
	/// <summary>
	/// Flexible StateActionSO for the StateMachine which allows to set any parameter on the Animator, in any moment of the state (OnStateEnter, OnStateExit, or each OnUpdate).
	/// </summary>
	[CreateAssetMenu(fileName = "CrouchActionSO", menuName = "State Machines/Actions/CrouchAction")]

	public class CrouchActionSO : StateActionSO
	{ 
		protected override StateAction CreateAction() => new CrouchAction();
	}

	public class CrouchAction : StateAction
	{
		//Component references
		private Camera _mainCamera;
		private GameObject _handTarget;
		private CharacterController _controller;


		private Vector3 _defaultCameraPos;
		public CrouchAction()
		{
		}

		public override void Awake(StateMachine stateMachine)
		{
			_mainCamera = Camera.main;
			_handTarget = GameObject.FindWithTag("HandTarget");
			_controller = stateMachine.GetComponent<CharacterController>();
		}

		public override void OnStateEnter()
		{
			Vector3 cameraPos = _mainCamera.transform.localPosition;
			_mainCamera.transform.localPosition = new Vector3(cameraPos.x, cameraPos.y - 0.3f, cameraPos.z);

			Vector3 handTargetPos = _handTarget.transform.localPosition;
			_handTarget.transform.localPosition = new Vector3(handTargetPos.x, handTargetPos.y - 0.3f, handTargetPos.z);
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

}