using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MainPlayer.Physics
{
    public class FearController : MonoBehaviour
    {
        public Image fearImage;
        public float fearDecreaseRate = 0.5f;
        public float maxFear = 100f;
        public float wrongWayFearIncreaseRate = 0.1f;

        private float _currentFear;
        private bool _wrongWay;

        private void Start() => fearImage.fillAmount = _currentFear / maxFear;

        private void Update()
        {
            _currentFear = _wrongWay
                ? Mathf.Clamp(_currentFear + (wrongWayFearIncreaseRate * Time.deltaTime), 0f, maxFear)
                : Mathf.Clamp(_currentFear - (fearDecreaseRate * Time.deltaTime), 0f, maxFear);
            fearImage.fillAmount = _currentFear / maxFear;

            if (_currentFear >= maxFear) SceneManager.LoadScene("MainHouse");
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("WrongWay")) _wrongWay = true;
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("WrongWay")) _wrongWay = false;

        }
    }
}
