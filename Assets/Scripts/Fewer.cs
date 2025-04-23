using UnityEngine;

public class Fewer : MonoBehaviour
{

    public float CurrentValue;

    public void AddFewerPoints(int Combo)
    {
        CurrentValue += Combo * 0.5f;
        if (CurrentValue > 100)
        {
            CurrentValue = 100;
        }
    }

    public void UseFewerMode()
    {
        CurrentValue -= 0.125f;
    }

}
