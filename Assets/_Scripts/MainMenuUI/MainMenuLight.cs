using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLight : MonoBehaviour
{
    [SerializeField] private float yDepth;
    [SerializeField] private RectTransform settingsTable;
    private Camera _camera;
    private bool _settingsFocus;
    private void Start()
    {
        _camera = Camera.main;
    }
    
    private void Update()
    {
        var ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hit))
        {
            var target = hit.point;
            transform.localPosition = new Vector3(target.x, yDepth, target.z);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out var hitted))
            {
                if(_settingsFocus) return;
                var obj = hitted.collider.gameObject;
                if (obj.CompareTag("Play"))
                {
                    SceneManager.LoadScene("MainHouse");
                }
                else if (obj.CompareTag("Quit"))
                {
                    Application.Quit();
                }
                else if (obj.CompareTag("Settings"))
                {
                    SettingsOpen();
                }
            }
        }
    }

    private void SettingsOpen()
    {
        _settingsFocus = true;
        settingsTable.DOAnchorPosY(0, 0.3f)
            .SetEase(Ease.InSine);
    }

    public void SettingsClose()
    {
        _settingsFocus = false;
        settingsTable.DOAnchorPosY(1200, 0.3f)
            .SetEase(Ease.OutSine);
    }
}