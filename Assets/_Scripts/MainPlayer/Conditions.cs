using System;
using System.Collections;
using UnityEngine;

namespace MainPlayer.Conditions
{
    public class Conditions : MonoBehaviour
    {
        private bool _canCheck = true;
        private StateMachine _stateMachine;

        public bool isGrounded;
        public bool isInInteraction;

        // public float distance;


        private void Awake()
        {
            _stateMachine = GetComponent<StateMachine>();
        }

        void Update()
        {
            IsGroundCheck();
            print(_stateMachine._currentState._originSO.name);
        }

        private void IsGroundCheck()
        {
            if(!_canCheck) return;
             // Debug.DrawRay(transform.position, Vector3.down * distance, Color.red);
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 1.0000001f))
            {
                isGrounded = true;
            }
            else
            {
                isGrounded = false;
            }
        }

        public IEnumerator Jump()
        {
            _canCheck = false;
            isGrounded = false;
            yield return new WaitForSeconds(0.4f);
            _canCheck = true;
        }
    }
}
