using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{

    [SerializeField] GameManager gameManager;

    [SerializeField] List<GameObject> _block;
    [SerializeField] Transform _spawnPosition;

    [HideInInspector] public int CurrentNbBlockStart = 0;
    public int NbBlockStart = 10;

    public float SpawnDelay = 1f;
    [HideInInspector] public float CurrentSpawnDelay = 0;


    List<Block> _blocksChain = new List<Block>();
    Block _lastBlockInChain;
    [SerializeField] int _layerBlock;

    [SerializeField] Score _scoreUi;
    [SerializeField] UIManager _uiManager;
    public List<Star> Stars;

    [SerializeField] Fewer _fewerUi;
    [HideInInspector] public bool IsFewer = false;


    private void Update()
    {
        if (!gameManager.IsPaused)
        {
            if (Input.GetMouseButton(0))
            {
                RaycastHit2D hit2D = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, 1, _layerBlock);
                if (hit2D.collider != null)
                {
                    if (hit2D.collider.gameObject.TryGetComponent<Block>(out Block component))
                    {
                        if (_blocksChain.Count == 0)
                        {
                            _blocksChain.Add(component);
                            _lastBlockInChain = component;
                            component.BecomeSelected();
                        }
                        else if (_blocksChain.Count > 0 && component.Type == _lastBlockInChain.Type)
                        {
                            Debug.Log("Un Autre");
                            _blocksChain.Add(component);
                            _lastBlockInChain = component;
                            component.BecomeSelected();
                        }
                    }
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                DestroyChains();
            }
            foreach (Star star in Stars)
            {
                if (_scoreUi.CurrentScore >= star.floorPoint)
                {
                    star.BecomeReached();
                }
            }
        }

    }

    public void GenerateNewBlocks()
    {
        int index = Random.Range(0, _block.Count);
        Instantiate(_block[index].transform, _spawnPosition.position + new Vector3(Random.Range(-3, 3), 0, 0), Quaternion.identity);
    }

    public void DestroyChains()
    {
        if (_blocksChain.Count > 0)
        {
            if (!IsFewer)
            {
                _scoreUi.AddScore(_blocksChain.Count);
                _uiManager.RefreshScoreUI();
                _fewerUi.AddFewerPoints(_blocksChain.Count);
                _uiManager.RefreshFewerUI();
            }
            else
            {
                _scoreUi.AddScoreDuringFewerMode(_blocksChain.Count);
                _uiManager.RefreshScoreUI();
            }
            for (int i = 0; i < _blocksChain.Count; i++)
            {
                Block block = _blocksChain[i];
                Destroy(block.gameObject);
                _blocksChain.Clear();
            }
        }
        if (_fewerUi.CurrentValue == 100)
        {
            IsFewer = true;
        }
    }

}
