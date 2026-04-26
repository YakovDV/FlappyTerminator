using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private GameObject _startPanel;
    [SerializeField] private GameObject _defeatPanel;
    [SerializeField] private Character _character;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private PlayerInput _playerInput;

    private void Start()
    {
        _startPanel.SetActive(true);
        _defeatPanel.SetActive(false);
        _scoreCounter.gameObject.SetActive(false);

        _playerInput.enabled = false;
        Time.timeScale = 0f;
    }

    private void OnEnable()
    {
        _character.Died += OnPlayerDied;
    }

    private void OnDisable()
    {
        _character.Died -= OnPlayerDied;
    }

    public void StartGame()
    {
        _startPanel.SetActive(false);
        _scoreCounter.gameObject.SetActive(true);

        _playerInput.enabled = true;
        _character.enabled = true;
        _enemySpawner.enabled = true;

        _scoreCounter.ResetScore();
        Time.timeScale = 1f;
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnPlayerDied()
    {
        _defeatPanel.SetActive(true);
        _enemySpawner.enabled = false;
        _playerInput.enabled = false;

        Time.timeScale = 0f;
    }
}