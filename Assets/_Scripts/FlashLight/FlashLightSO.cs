using TMPro;
using UnityEngine;

namespace MainPlayer.FlashLight
{
    [CreateAssetMenu(fileName = "FlashlightData", menuName = "MainPlayer/Data/FlashlightData")]
    public class FlashLightSO : ScriptableObject
    {
        private TextMeshProUGUI _batteryText;
        
        [SerializeField] private int batteryCount;
        public int BatteryCount => batteryCount;

        [SerializeField] private float batteryUseSpeed;
        public float BatteryUseSpeed => batteryUseSpeed;

        [SerializeField] private float batteryFillSpeed;
        public float BatteryFillSpeed => batteryFillSpeed;

        public void InitVariables(TextMeshProUGUI text)
        {
            _batteryText = text;
            
            
            batteryCount = PlayerPrefs.GetInt(PlayerPrefsLibrary.BatteryPlayerPrefsKey, 0);
            _batteryText.text = batteryCount.ToString();
        }
        
        public void AddBattery()
        {
            batteryCount++;
            PlayerPrefs.SetInt(PlayerPrefsLibrary.BatteryPlayerPrefsKey, batteryCount);
            _batteryText.text = batteryCount.ToString();
        }

        public void UseBattery()
        {
            batteryCount--;
            PlayerPrefs.SetInt(PlayerPrefsLibrary.BatteryPlayerPrefsKey, batteryCount);
            _batteryText.text = batteryCount.ToString();
        }
    }
}
