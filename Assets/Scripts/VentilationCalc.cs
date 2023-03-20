using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentilationCalc : MonoBehaviour
{
    public Temperature temperature, outsideTemp;
    public float heatRecoveryRate;

    public float acPowerUsage;

    public float acPowerEfficiency;

    public bool acOn;


    [SerializeField]
    private float ach; // air changes per hour

    private float shc = 1010; //specific heat capacity J/(K*kg)
    private double tempDiff;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        tempDiff = temperature.temperature - outsideTemp.temperature;
        Ventilation();
    }



    private void Ventilation()
    {
        tempDiff -= tempDiff * heatRecoveryRate;
        float volume = temperature.length * temperature.width * temperature.height;
        double power = volume * tempDiff * ach * 0.33;
        if (acOn)
        {
            power -= acPowerEfficiency * acPowerUsage;
            Variables.Instance.WattsSpend(acPowerUsage);
        }
        temperature.temperature -= (power * Time.deltaTime * Variables.Instance.timeScale) / (shc * temperature.mass);
    }
}
