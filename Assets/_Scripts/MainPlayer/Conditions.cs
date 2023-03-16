using System;
using System.Collections;
using UnityEngine;

namespace MainPlayer.Conditions
{
    public class Conditions : MonoBehaviour
    {
        internal bool CanCheck = true;
        private StateMachine _stateMachine;

        public bool isGrounded;
        public bool isInInteraction;




        private void Awake()
        {
            _stateMachine = GetComponent<StateMachine>();
        }

        void Update()
        {
            print(_stateMachine._currentState._originSO.name);
        }
        

        public IEnumerator Jump()
        {
            CanCheck = false;
            isGrounded = false;
            yield return new WaitForSeconds(1.2f);
            isGrounded = true;
        }

    }
}