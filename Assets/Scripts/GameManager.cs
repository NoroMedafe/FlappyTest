using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Player _player;

    [SerializeField] private Text _scoreText;
    [SerializeField] private GameObject _playButton;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private int _score;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private GameObject _lvlButtons;
    public int Score => _score;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
        
    }

    public void Play()
    {
        _score = 0;
        _scoreText.text = _score.ToString();

        _playButton.SetActive(false);
        _losePanel.SetActive(false);

        Time.timeScale = 1f;
        _player.enabled = true;
        _lvlButtons.SetActive(false);
        _spawner.ClearAllPipes();
    }

    public void GameOver()
    {
        _playButton.SetActive(true);
        _losePanel.SetActive(true);
        _lvlButtons.SetActive(true);

        Pause();
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        _player.enabled = false;
    }

    public void IncreaseScore()
    {
        _score++;
        _scoreText.text = _score.ToString();
    }

}
