using System;
using System.Collections;
using System.Collections.Generic;
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

        public void InitVariables()
        {
            batteryCount = PlayerPrefs.GetInt("Battery", 0);
            _batteryText = GameObject.Find("BatteryText").GetComponent<TextMeshProUGUI>();
            _batteryText.text = batteryCount.ToString();
        }
        
        public void AddBattery()
        {
            batteryCount++;
            PlayerPrefs.SetInt("Battery", batteryCount);
            _batteryText.text = batteryCount.ToString();
        }

        public void UseBattery()
        {
            batteryCount--;
            PlayerPrefs.SetInt("Battery", batteryCount);
            _batteryText.text = batteryCount.ToString();
        }
    }
}
