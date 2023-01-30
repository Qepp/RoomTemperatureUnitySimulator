using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temperature : MonoBehaviour
{
    public double temperature;
    public float length, width, height;
    public double mass, surfaceArea;
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
        //tempDiff = temperature - ventiOtherSide.temperature;
        //FabricHeatLoss();
        //Ventilation();
    }


    public void HeatByWatts(float power)
    {
        Variables.Instance.WattsSpend(power);
        temperature += (power * Time.deltaTime * Variables.Instance.timeScale) / (shc * mass);
    }
}
