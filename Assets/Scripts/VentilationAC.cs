using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentilationAC : MonoBehaviour
{
    public Temperature temperature, outsideTemp;

    [SerializeField]
    private float ach; // air changes per hour



    private float shc = 1010; //specific heat capacity J/(K*kg)
    private double tempDiff;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        tempDiff = temperature.temperature - outsideTemp.temperature;
        Ventilation();
    }



    private void Ventilation()
    {
        float volume = temperature.length * temperature.width * temperature.height;
        double power = volume * tempDiff * ach * 0.33;
        temperature.temperature -= (power * Time.deltaTime * Variables.Instance.timeScale) / (shc * temperature.mass);
    }


}
