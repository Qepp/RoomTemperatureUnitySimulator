using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabricHeatLossCalc : MonoBehaviour
{
    public Temperature temperature;
    [SerializeField]
    private float length, width, height;

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
        foreach (Wall wall in walls)
        {
            
            FabricHeatLoss(wall);
        }

 
    }

    private void FabricHeatLoss(Wall wall)
    {
        var outTemp = wall.otherSide.GetComponent<Temperature>();
        tempDiff = temperature.temperature - outTemp.temperature;
        double power = wall.surfaceArea * wall.uValue * tempDiff / 1000;
        Debug.Log(power);
        temperature.temperature -= (power * Time.deltaTime * Variables.Instance.timeScale) / (shc * mass);
    }




}
