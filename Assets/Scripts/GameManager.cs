using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] BlockManager _blockManager;
    [SerializeField] UIManager _uiManager;

    [SerializeField] Timer _timer;
    
    private void Awake()
    {
        _timer.CurrentTime = _timer.StartLevelTime;
    }


    // Start is called before the first frame update
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

    // Update is called once per frame
    void Update()
    {
        if (_timer.CurrentTime <= 0)
        {
            Debug.Log("End of The Game");
        }
        else
        {
            _timer.CurrentTime -= Time.deltaTime;
            _uiManager.RefreshTimerUI();
        }
    }
}
