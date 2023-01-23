using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temperature : MonoBehaviour
{
    public double temperature, outsideTemp;
    [SerializeField]
    private float length, width, height, wallRvalue;
    [SerializeField]
    private float uValue;
    [SerializeField]
    private float ach; // air changes per hour
    private double mass, surfaceArea;
    private float shc = 1010; //specific heat capacity J/(K*kg)
    private double tempDiff;

    private void Awake()
    {
        mass = 1.2 * length * width * height;
        surfaceArea = length * height * 2 + length * width + width * height * 2;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tempDiff = temperature - outsideTemp;
        FabricHeatLoss();
        Ventilation();
    }

    private void FabricHeatLoss()
    {       
        double power = surfaceArea * uValue * tempDiff / 1000;
        temperature -= (power * Time.deltaTime * Variables.Instance.timeScale) / (shc * mass);
    }

    private void Ventilation()
    {
        float volume = length * width * height;
        double power = volume * tempDiff * ach * 0.33;
        temperature -= (power * Time.deltaTime * Variables.Instance.timeScale) / (shc * mass);
    }

    public void HeatByWatts(float power)
    {
        temperature += (power * Time.deltaTime * Variables.Instance.timeScale) / (shc * mass);
    }
}
