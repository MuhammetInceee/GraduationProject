using System.Threading.Tasks;
using Game.Interafaces;
using TMPro;
using UnityEngine;
using MainPlayer.Conditions;

public class TextVisualizer : MonoBehaviour, IInteractable
{
    [SerializeField] private StringSO text;
    private GameObject _canvas;
    private TextMeshProUGUI _textMesh;

    private void Start()
    {
        _canvas = transform.GetChild(0).gameObject;
        _textMesh = _canvas.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
    }

    public void Execute()
    {
        _canvas.SetActive(true);
        _textMesh.text = text.value;
        CanvasCloser();
        GameEndCheck();
    }

    private async void CanvasCloser()
    {
        await Task.Delay(8000);
        _canvas.SetActive(false);
    }

    private async void GameEndCheck()
    {
        if(gameObject.name != "Bed") return;
        var end = FindObjectOfType<GameEndManager>();
        var condition = FindObjectOfType<Conditions>();

        condition.canGetSettings = true;
        await Task.Delay(8000);
        end.gameEnd.SetActive(true);
        await Task.Delay(5000);
        Application.Quit();
    }
}
