using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WallHeater : Heater
{
    //public Temperature room;
    public double heaterTemp;
    public double heaterMaxTemp;
    [Tooltip("KG")]
    public float mass;
    [Tooltip("Specific heat capacity")]
    public float shc;
    public float surfaceArea;
    [Tooltip("Heat transfer coefficient")]
    public float htc;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (heaterTemp <= heaterMaxTemp)
        {
            HeatHeater();
        }
        HeatAir();
    }

    private void HeatHeater()
    {
        Variables.Instance.WattsSpend(power);
        heaterTemp += ((power/1000) *Time.deltaTime * Variables.Instance.timeScale) / (mass * shc);
    }

    private void HeatAir()
    {
        double wattChange = surfaceArea * htc * (heaterTemp - airTemp.temperature);
        airTemp.HeatByWatts(wattChange);
        heaterTemp -= ((wattChange / 1000) * Time.deltaTime * Variables.Instance.timeScale) / (mass * shc);
    }


    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.CompareTag("Room"))
        {
            airTemp = other.gameObject.GetComponent<Temperature>();
        }
    }
}
