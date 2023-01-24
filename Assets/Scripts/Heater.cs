using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Thermostat))]
public class Heater : MonoBehaviour
{
    public Temperature airTemp;
    public double temperature;
    [Header("Power output in W")]
    public float maxPower;
    [SerializeField]
    private float power;
    [SerializeField]
    private float warmUpTime;
    public Image onLight;
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
        onLight.color = Color.green;
    }

    public void DisableHeater()
    {
        power = 0;
        onLight.color = Color.red;
    }

    private void HeatAir()
    {
        airTemp.HeatByWatts(power);
    }
}
