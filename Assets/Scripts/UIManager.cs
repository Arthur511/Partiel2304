using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI _textScore;
    [SerializeField] Score _scoreUi;

    [SerializeField] TextMeshProUGUI _textTimer;
    [SerializeField] Image _imageTimer;
    [SerializeField] Timer _timerUi;
    public void RefreshScoreUI()
    {
        _textScore.text = _scoreUi.CurrentScore.ToString();
    }

    public void RefreshTimerUI()
    {
        _imageTimer.fillAmount = _timerUi.CurrentTime/_timerUi.StartLevelTime;
        _textTimer.text = _timerUi.ToString();
    }
}
