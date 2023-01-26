using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentilationAC : MonoBehaviour
{
    public Temperature temperature, outsideTemp;
    [SerializeField]
    private float length, width, height, wallRvalue;
    [SerializeField]
    private float uValue;
    [SerializeField]
    private float ach; // air changes per hour
    public List<Wall> walls = new List<Wall>();

    [SerializeField]
    private double temp;

    private double mass, surfaceArea;
    private float shc = 1010; //specific heat capacity J/(K*kg)
    private double tempDiff;



    [System.Serializable]
    public struct Wall
    {
        public float surfaceArea;
        public float uValue;
        public Transform otherSide;
    }

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
        tempDiff = temperature.temperature - outsideTemp.temperature;
        Ventilation();
    }



    private void Ventilation()
    {
        float volume = length * width * height;
        double power = volume * tempDiff * ach * 0.33;
        temperature.temperature -= (power * Time.deltaTime * Variables.Instance.timeScale) / (shc * mass);
    }


}