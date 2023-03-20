using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MainPlayer.FlashLight
{
    public class FlashLight : MonoBehaviour
    {
        private const float BatteryCapacity = 100f;
        private float _batteryLevel;
        private FlashLightSO _flashLightSO;

        [SerializeField] private Slider batterySlider;
        [SerializeField] private Light flashlight;


        public float batteryFillSpeed = 10;
        public float batteryUseSpeed = 2;
        

        void Awake()
        {
            InitVariable();
            ReadDataFromResource();
            
            _flashLightSO.InitVariables();
        }

        void Update()
        {
            FlashLightToggle();
            RefillBattery();
            HandleFlashlightBattery();
        }

        #region Awake Methods

        private void InitVariable()
        {
            _batteryLevel = BatteryCapacity;
            batterySlider.maxValue = BatteryCapacity;
            batterySlider.value = BatteryCapacity;
        }

        private void ReadDataFromResource()
        {
            _flashLightSO = Resources.Load<FlashLightSO>("Flashlight/FlashlightData");
        }

        #endregion
        
        #region Update Methods

        private void HandleFlashlightBattery()
        {
            if (flashlight.enabled)
            {
                _batteryLevel -= Time.deltaTime *  batteryUseSpeed;
                batterySlider.value = _batteryLevel;
                if (_batteryLevel <= 0f)
                {
                    flashlight.enabled = false;
                }
            }
        }

        private void RefillBattery()
        {
            if (Input.GetKeyDown(KeyCode.R) && _flashLightSO.BatteryCount > 0)
            {
                _batteryLevel = 100f;
                batterySlider.value = _batteryLevel;
                FillBattery();
                _flashLightSO.UseBattery();
            }
        }

        private void FlashLightToggle()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                flashlight.enabled = !flashlight.enabled;
            }
        }

        void FillBattery()
        {
            while (_batteryLevel < BatteryCapacity)
            {
                _batteryLevel += Time.deltaTime * batteryFillSpeed;
                _batteryLevel = Mathf.Min(_batteryLevel, BatteryCapacity);
                batterySlider.value = _batteryLevel;
                if (_batteryLevel >= BatteryCapacity)
                {
                    break;
                }
            }
        }

        #endregion
        
    }
}