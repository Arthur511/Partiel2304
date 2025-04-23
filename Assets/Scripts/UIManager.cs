using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    [SerializeField] GameObject _pauseBackground;

    [SerializeField] TextMeshProUGUI _textScore;
    [SerializeField] Score _scoreUi;

    [SerializeField] TextMeshProUGUI _textTimer;
    [SerializeField] Image _imageTimer;
    [SerializeField] Timer _timerUi;

    [SerializeField] Image _imageFewer;
    [SerializeField] Fewer _fewerUi;

    [SerializeField] TextMeshProUGUI _textHighScoreDefeat;
    [SerializeField] TextMeshProUGUI _textHighScoreVictory;

    public void RefreshScoreUI()
    {
        _textScore.text = _scoreUi.CurrentScore.ToString();
    }

    public void RefreshTimerUI()
    {
        _imageTimer.fillAmount = _timerUi.CurrentTime/_timerUi.StartLevelTime;
        _textTimer.text = ((int)_timerUi.CurrentTime).ToString();
    }

    public void RefreshFewerUI()
    {
        _imageFewer.fillAmount = _fewerUi.CurrentValue / 100;
    }

    public void PauseButton()
    {
        gameManager.IsPaused = !gameManager.IsPaused;
        _pauseBackground.SetActive(gameManager.IsPaused);
    }

    public void DisplayHighScore()
    {
        _textHighScoreDefeat.text = gameManager._highScore.ToString();
        _textHighScoreVictory.text = gameManager._highScore.ToString();
    }
}
