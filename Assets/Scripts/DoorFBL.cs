using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorFBL : WallFBL
{

    public bool doorOpen;

    [Tooltip("Number that can be set what ever so that calculations are correct")]
    public double magicAirChange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (doorOpen)
        {
            MixOpenDoorAir();
        } else
        {
            HeatExchange();
        }
    }

    public void MixOpenDoorAir()
    {
        double tempDelta = temperature1.temperature - temperature2.temperature;
        double airFlow = surfaceArea * magicAirChange;
        double power = tempDelta * shc * airFlow;
        temperature1.temperature -= (power * Time.deltaTime * Variables.Instance.timeScale) / (shc * temperature1.mass);
        temperature2.temperature += (power * Time.deltaTime * Variables.Instance.timeScale) / (shc * temperature2.mass);
    }
}
