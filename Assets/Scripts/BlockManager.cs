using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{

    [SerializeField] GameObject _block;
    [SerializeField] Transform _spawnPosition;

    float _spawnDelay = 1;
    float _currentSpawnDelay;
    public float CurrentSpawnDelay { get; set; }
    public float SpawnDelay { get; private set; }
    public void GenerateBlocksLevel()
    {
        
    }

    public void GenerateNewBlocks()
    {
        Instantiate(_block.transform, _spawnPosition.position + new Vector3 (Random.Range(-10, 10), 0, 0), Quaternion.identity);
    }

}
