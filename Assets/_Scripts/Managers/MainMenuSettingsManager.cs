using MainPlayer.Data;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuSettingsManager : MonoBehaviour
{
    [SerializeField] private AudioSource bgMusic;
    [SerializeField] private PlayerMovementDataSO playerData;
    
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Slider sensitivitySlider;


    private void Awake()
    {
        volumeSlider.value = bgMusic.volume;
        sensitivitySlider.value = playerData.MouseSensitivity / 200;
    }

    private void Update()
    {
        bgMusic.volume = volumeSlider.value;
        playerData.MouseSensitivity = sensitivitySlider.value * 200;
    }
}