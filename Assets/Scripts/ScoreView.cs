using TMPro;
using UnityEngine;

public class ScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _textMeshProUGUI;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private string _preText = "Score: ";

    private void Awake()
    {
        _textMeshProUGUI.text = _preText + 0;
    }

    private void OnEnable()
    {
        _scoreCounter.ValueChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _scoreCounter.ValueChanged -= OnValueChanged;
    }

    private void OnValueChanged(int value)
    {
        _textMeshProUGUI.text = _preText + value.ToString();
    }
}