using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{

    [SerializeField] List<GameObject> _block;
    [SerializeField] Transform _spawnPosition;

    [HideInInspector] public int CurrentNbBlockStart = 0;
    public int NbBlockStart = 10;

    public float SpawnDelay = 1f;
    [HideInInspector] public float CurrentSpawnDelay = 0;


    List<Block> _blocksChain = new List<Block>();
    Block _lastBlockInChain;

    [SerializeField] Score _scoreUi;
    [SerializeField] UIManager _uiManager;
    /*int _nbBlockStart = 15;
    int _currentNbBlockStart;
    public int CurrentNbBlockStart { 
        get => _currentNbBlockStart;
        set
        {
            _currentNbBlockStart = value;
        }
    }
    public int NbBlockStart
    {
        get => _nbBlockStart;
        set
        {
            _nbBlockStart = value;
        }
    }


    
    float _spawnDelay = 0.5f;
    float _currentSpawnDelay = 0;
    public float CurrentSpawnDelay { 
        get => _currentSpawnDelay;
        set 
        {
            _currentSpawnDelay = value;
        } 
    }
    public float SpawnDelay {
        get => _spawnDelay; 
        set 
        { 
            _spawnDelay = value;
        } 
    }*/
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit2D = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit2D.collider != null)
            {
                if(hit2D.collider.gameObject.TryGetComponent<Block>(out Block component))
                {
                    Debug.Log("Touchez !!");
                    if (_blocksChain.Count == 0)
                    {
                        _blocksChain.Add(component);
                        _lastBlockInChain = component;
                    }
                    else if (_blocksChain.Count > 0 && component.Type == _lastBlockInChain.Type)
                    {
                        Debug.Log("Un Autre");
                        _blocksChain.Add(component);
                        _lastBlockInChain = component;
                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (_blocksChain.Count > 0)
            {
                _scoreUi.AddScore(_blocksChain.Count);
                _uiManager.RefreshScoreUI();
                for (int i = 0; i < _blocksChain.Count; i++)
                {
                    Block block = _blocksChain[i];
                    Destroy(block.gameObject);
                    _blocksChain.Clear();
                }
            }
        }
    }

    public void GenerateNewBlocks()
    {
        int index = Random.Range(0, _block.Count);
        Instantiate(_block[index].transform, _spawnPosition.position + new Vector3(Random.Range(-3, 3), 0, 0), Quaternion.identity);
    }

    public void SnapOneBlock()
    {

    }

    public void DestroyChains()
    {
        
    }

}
