using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Block : MonoBehaviour
{
    int _id;
    public int Type;

    [SerializeField] Sprite _outlineImage;

    [SerializeField] GameObject _clickableCollider;

    public void BecomeSelected()
    {
        GetComponent<SpriteRenderer>().sprite = _outlineImage;
        _clickableCollider.SetActive(false);
    }

}
