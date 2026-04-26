using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]

public class StartButton : MonoBehaviour
{
    [SerializeField] private Game _game;

    private Button _button;

    public void Awake()
    {
        _button = GetComponent<Button>();
    }

    protected void OnEnable()
    {
        _button.onClick.AddListener(StartGame);
    }

    protected void OnDisable()
    {
        _button.onClick.RemoveListener(StartGame);
    }

    private void StartGame()
    {
        _game.StartGame();
    }
}
