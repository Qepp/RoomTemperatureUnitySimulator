using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{
    public static Variables Instance { get; private set; }
    public float timeScale;
    public double totalWattageUsed = 0;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        } 
        else
        {
            Instance = this;
        }
    }

    public void WattsSpend(double watts)
    {
        totalWattageUsed += System.Math.Abs(watts) * timeScale;
    }
}
