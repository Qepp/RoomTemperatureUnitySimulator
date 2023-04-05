using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutsideTemperatureChanger : MonoBehaviour
{

    [SerializeField]
    private Temperature outTemp;

    public double maxTemperature, minTemperature, tempChangeAmount;
    public double targetTemp;
    public double oldTemp;
    public double tempChangeInterval;

    private double nextTempChange = 0;
    // Start is called before the first frame update
    void Start()
    {
        oldTemp = outTemp.temperature;
    }

    // Update is called once per frame
    void Update()
    {
        nextTempChange += Time.deltaTime * Variables.Instance.timeScale;
        if(nextTempChange >= tempChangeInterval)
        {
            UpdateTargetTemperature(CalculateNewTemp());
            nextTempChange -= tempChangeInterval;
        }
        UpdateTemperature();
    }

    double CalculateNewTemp()
    {
        double newTemp = outTemp.temperature;
        newTemp += Random.Range((float)-tempChangeAmount, (float)tempChangeAmount);
        if (newTemp < minTemperature)
        {
            newTemp = minTemperature;
        } 
        if (newTemp > maxTemperature)
        {
            newTemp = maxTemperature;
        }
        return newTemp;

    }

    public void UpdateTargetTemperature(double newTemp)
    {
        oldTemp = targetTemp;
        targetTemp = newTemp;

    }

    public void UpdateTemperature()
    {
        Debug.Log(Variables.Instance.LerpDouple(oldTemp, targetTemp, nextTempChange / tempChangeInterval));
        outTemp.temperature = Variables.Instance.LerpDouple(oldTemp, targetTemp, nextTempChange/tempChangeInterval);
    }
}
