using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace MainPlayer.Physics
{
    public class FearController : MonoBehaviour
    {
        public Image fearImage;
        public float fearDecreaseRate = 0.5f;
        public float maxFear = 100f;
        public float wrongWayFearIncreaseRate = 0.1f;

        private float _currentFear = 0f;
        private bool _wrongWay;

        void Start()
        {
            
            fearImage.fillAmount = _currentFear / maxFear;
        }

        void Update()
        {
            print(_wrongWay);

            _currentFear = _wrongWay
                ? Mathf.Clamp(_currentFear + (wrongWayFearIncreaseRate * Time.deltaTime), 0f, maxFear)
                : Mathf.Clamp(_currentFear - (fearDecreaseRate * Time.deltaTime), 0f, maxFear);

            fearImage.fillAmount = _currentFear / maxFear;
        }

        void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("WrongWay"))
            {
                _wrongWay = true;
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("WrongWay"))
            {
                _wrongWay = false;
            }
        }
    }
}
