using System;
using System.Threading.Tasks;
using Game.Interafaces;
using TMPro;
using UnityEngine;

public class TextVisualizer : MonoBehaviour, IInteractable
{
    [SerializeField] private StringSO text;
    private GameObject _canvas;
    private TextMeshProUGUI _textMesh;

    private void Start()
    {
        _canvas = transform.GetChild(0).gameObject;
        _textMesh = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Execute()
    {
        _canvas.SetActive(true);
        _textMesh.text = text.value;
        CanvasCloser();
    }

    private async void CanvasCloser()
    {
        await Task.Delay(8000);
        _canvas.SetActive(false);
    }
}
