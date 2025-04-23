using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Star : MonoBehaviour
{

    public int floorPoint;

    public void BecomeReached()
    {
        GetComponent<Image>().color = Color.yellow;
    }
}
