using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MainPlayer.FlashLight
{
    public class FlashLight : MonoBehaviour
    {
        private const float BatteryCapacity = 100f;
        private float _batteryLevel;
        private FlashLightSO _flashLightSettings;
        private Light _flashlight;

        [Header("About UI")]
        [SerializeField] private Image batteryImage;
        [SerializeField] private TextMeshProUGUI batteryText;

        void Awake()
        {
            ReadDataFromResource();
            InitVariable();
            _flashLightSettings.InitVariables(batteryText);
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
            _flashlight = GetComponent<Light>();
            _batteryLevel = BatteryCapacity;
            batteryImage.fillAmount = 1f;
        }

        private void ReadDataFromResource()
        {
            _flashLightSettings = Resources.Load<FlashLightSO>("Flashlight/FlashlightData");
        }

        #endregion

        #region Update Methods

        private void HandleFlashlightBattery()
        {
            if (_flashlight.enabled)
            {
                _batteryLevel -= Time.deltaTime * _flashLightSettings.BatteryUseSpeed;
                batteryImage.fillAmount = _batteryLevel / BatteryCapacity;
                if (_batteryLevel <= 0f)
                {
                    _flashlight.enabled = false;
                }
            }
        }

        private void RefillBattery()
        {
            if (Input.GetKeyDown(KeyCode.R) && _flashLightSettings.BatteryCount > 0)
            {
                _batteryLevel = BatteryCapacity;
                batteryImage.fillAmount = 1f;
                FillBattery();
                _flashLightSettings.UseBattery();
            }
        }

        private void FlashLightToggle()
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                _flashlight.enabled = !_flashlight.enabled;
            }
        }

        void FillBattery()
        {
            while (_batteryLevel < BatteryCapacity)
            {
                _batteryLevel += Time.deltaTime * _flashLightSettings.BatteryFillSpeed;
                _batteryLevel = Mathf.Min(_batteryLevel, BatteryCapacity);
                batteryImage.fillAmount = _batteryLevel / BatteryCapacity;
                if (_batteryLevel >= BatteryCapacity)
                {
                    break;
                }
            }
        }

        #endregion
    }
}
