using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class RestartButton : MonoBehaviour
{
    [SerializeField] private Game _game;

    private Button _button;

    public void Awake()
    {
        _button = GetComponent<Button>();
    }

    protected void OnEnable()
    {
        _button.onClick.AddListener(RestartGame);
    }

    protected void OnDisable()
    {
        _button.onClick.RemoveListener(RestartGame);
    }

    private void RestartGame()
    {
        _game.RestartGame();
    }
}