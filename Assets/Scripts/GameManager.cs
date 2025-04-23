using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField] BlockManager _blockManager;

    // Start is called before the first frame update
    void Start()
    {
        _blockManager.CurrentSpawnDelay = _blockManager.SpawnDelay;
        while (true)
        {
            if (_blockManager.CurrentSpawnDelay == 0)
            {
                _blockManager.GenerateNewBlocks();
                _blockManager.CurrentSpawnDelay = _blockManager.SpawnDelay;
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

    }
}
