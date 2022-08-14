using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _timer;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _finalText;

    [SerializeField] private GameObject _gameOverMenu;
    [SerializeField] private GameObject _pauseButton;

    [SerializeField] private float _startTimer;
    [SerializeField] private float _countdownTimer = 0f;
    
    private int _score;
    public TMP_InputField _playerName;
    
    private bool _lampLight = false;
    private float _emissionFadeOut = 0.5f;
    private float _emissionCounter = 0;

    [SerializeField] GameObject _lamp;
    public void Start()
    {
        _score = 0;
        Time.timeScale = 1;
        _countdownTimer = _startTimer;
        _timer.color = Color.white;
        _gameOverMenu.SetActive(false);
    }
    public void Update()
    {
        ControllLampFeedback();
    }

    public void FixedUpdate()
    {
        if (_countdownTimer > 0f)
        {
            _countdownTimer -= 1 * Time.deltaTime;
            if (_countdownTimer <= 10f)
            {
                _timer.color = Color.red;
            }
        }

        _timer.text = _countdownTimer.ToString("0");

        if (_countdownTimer <= 0f)
        {
            _countdownTimer = 0;
            GameOver();
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        _pauseButton.SetActive(false);
        _gameOverMenu.SetActive(true);
        _scoreText.gameObject.SetActive(false);
    }

    public void IncrementScore()
    {
        LightFeedback();
        _score += 1;
        _scoreText.text = _score.ToString();
        _finalText.text = _score.ToString();
    }
    public void ControllLampFeedback()
    {
        if (_lampLight && _emissionCounter < _emissionFadeOut)
            _emissionCounter += Time.deltaTime;
        else if (_lampLight)
        {
            _lamp.GetComponent<MeshRenderer>().material.DisableKeyword("_EMISSION");
            _lamp.GetComponentInChildren<Light>().enabled = false;
            _lampLight = false;
            _emissionCounter = 0;
        }
    }

    public void LightFeedback()
    {
        _lamp.GetComponent<MeshRenderer>().material.EnableKeyword("_EMISSION");
        _lamp.GetComponentInChildren<Light>().enabled = true;

        _lampLight = true;
    }

    public void SubmitScore()
    {
        if (string.IsNullOrEmpty(_playerName.text))
            return;
        
        var scoreClient = new ScoresClient();
        scoreClient.PostPlayerScore(_playerName.text, _score);

        SceneManager.LoadScene("HighScore");
    }
}
