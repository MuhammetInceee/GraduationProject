using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLight : MonoBehaviour
{
    [SerializeField] private float yDepth;
    private Camera _camera;

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
                    
                }
            }
        }
    }
}