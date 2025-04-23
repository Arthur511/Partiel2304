using UnityEngine;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public int _highScore = 0;

    [SerializeField] BlockManager _blockManager;
    [SerializeField] UIManager _uiManager;

    [SerializeField] Timer _timer;
    [SerializeField] Score _score;
    [SerializeField] Fewer _fewerFill;

    public bool IsPaused = false;

    [SerializeField] GameObject _defeatScreen;
    [SerializeField] GameObject _victoryScreen;

    private void Awake()
    {
        _timer.CurrentTime = _timer.StartLevelTime;
        _score.CurrentScore = 0;
    }

    void Start()
    {
        _blockManager.CurrentSpawnDelay = _blockManager.SpawnDelay;
        _blockManager.CurrentNbBlockStart = 0;
        while (_blockManager.CurrentNbBlockStart < _blockManager.NbBlockStart)
        {
            if (_blockManager.CurrentSpawnDelay <= 0)
            {
                _blockManager.GenerateNewBlocks();
                _blockManager.CurrentSpawnDelay = _blockManager.SpawnDelay;
                _blockManager.CurrentNbBlockStart++;
            }
            else
            {
                _blockManager.CurrentSpawnDelay -= Time.deltaTime;
            }
        }
    }

    void Update()
    {
        if (!IsPaused)
        {
            if (_timer.CurrentTime <= 0)
            {
                _timer.CurrentTime = 0;

                Debug.Log("End of The Game");

                if (_score.CurrentScore < _blockManager.Stars[0].floorPoint)
                {
                    _defeatScreen.SetActive(true);
                    if (_score.CurrentScore > _highScore)
                        _highScore = _score.CurrentScore;
                    _uiManager.DisplayHighScore();
                }
                IsPaused = true;
            }
            else
            {
                _timer.CurrentTime -= Time.deltaTime;
                _uiManager.RefreshTimerUI();
            }

            if (_blockManager.IsFewer)
            {
                _fewerFill.UseFewerMode();
                _uiManager.RefreshFewerUI();
                if (_fewerFill.CurrentValue == 0)
                {
                    _blockManager.IsFewer = false;
                }
            }

            if (_score.CurrentScore >= _blockManager.Stars[_blockManager.Stars.Count - 1].floorPoint)
            {
                _uiManager.DisplayHighScore();
                if (_score.CurrentScore > _highScore)
                    _highScore = _score.CurrentScore;
                _victoryScreen.SetActive(true);
                IsPaused = true;
            }
        }
    }
}

