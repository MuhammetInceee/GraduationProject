using System;
using System.Collections;
using UnityEngine;

namespace MainPlayer.Conditions
{
    public class Conditions : MonoBehaviour
    {
        internal bool CanCheck = true;

        public bool isGrounded;
        public bool isInInteraction;

        public IEnumerator Jump()
        {
            CanCheck = false;
            isGrounded = false;
            yield return new WaitForSeconds(1.2f);
            isGrounded = true;
        }

    }
}