using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Variables : MonoBehaviour
{
    public static Variables Instance { get; private set; }
    public float timeScale;
    public double EnergyUsedKWh = 0;
    public double SecondsGone = 0;
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
        EnergyUsedKWh += ((System.Math.Abs(watts) * timeScale * Time.deltaTime)/3600)/1000;
    }

    private void Update()
    {
        UpdateTime();

    }

    private void UpdateTime()
    {
        SecondsGone += Time.deltaTime * timeScale;
    }
}
