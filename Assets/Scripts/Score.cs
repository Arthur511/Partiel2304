using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    
    public int CurrentScore = 0;

    public void AddScore(int Combo)
    {
        CurrentScore += Combo * 500;
    }

}
