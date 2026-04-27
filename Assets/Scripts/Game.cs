using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private StartScreen _startPanel;
    [SerializeField] private RestartScreen _defeatPanel;
    [SerializeField] private Character _character;
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private EnemySpawner _enemySpawner;
    [SerializeField] private BulletPool _enemyBulletPool;
    [SerializeField] private BulletPool _characterBulletPool;
    [SerializeField] private EnemyPool _enemyPool;

    private void Start()
    {
        _startPanel.Open();
        _defeatPanel.Close();
        _scoreCounter.gameObject.SetActive(false);
        _playerInput.enabled = false;

        Time.timeScale = 0f;
    }

    private void OnEnable()
    {
        _character.Died += OnPlayerDied;
        _startPanel.PlayButtonClicked += StartGame;
        _defeatPanel.RestartButtonClicked += RestartGame;
    }

    private void OnDisable()
    {
        _character.Died -= OnPlayerDied;
        _startPanel.PlayButtonClicked -= StartGame;
        _defeatPanel.RestartButtonClicked -= RestartGame;
    }

    private void StartGame()
    {
        _startPanel.Close();
        _scoreCounter.gameObject.SetActive(true);

        _playerInput.enabled = true;
        _enemySpawner.enabled = true;

        _scoreCounter.ResetScore();
        Time.timeScale = 1f;
    }

    private void RestartGame()
    {
        _characterBulletPool.ReleaseAllObjects();
        _enemyBulletPool.ReleaseAllObjects();
        _enemyPool.ReleaseAllObjects();

        _character.ResetPosition();
        _enemySpawner.enabled = true;
        _playerInput.enabled = true;

        _defeatPanel.Close();
        _scoreCounter.ResetScore();

        Time.timeScale = 1f;
    }

    private void OnPlayerDied()
    {
        Time.timeScale = 0f;
        _defeatPanel.Open();
        _enemySpawner.enabled = false;
        _playerInput.enabled = false;
    }
}