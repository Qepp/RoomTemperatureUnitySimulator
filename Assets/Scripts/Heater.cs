using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Thermostat))]
public class Heater : MonoBehaviour
{
    public Temperature airTemp;
    public double temperature;
    [Header("Power output in W")]
    public float maxPower;
    private float power;
    void Start()
    {
        power = 0;
    }

    // Update is called once per frame
    void Update()
    {
        HeatAir();
    }

    public void EnableHeater()
    {
        power = maxPower;
    }

    public void DisableHeater()
    {
        power = 0;
    }

    private void HeatAir()
    {
        airTemp.HeatByWatts(power);
    }
}
