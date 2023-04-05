using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallFBL : MonoBehaviour
{
    [Tooltip("In square meters")]
    public float surfaceArea; //square meters;

    public float uValue;
    public Temperature temperature1, temperature2;

    protected float shc = 1010; //specific heat capacity J/(K*kg)
    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected void Reset()
    {
        surfaceArea = transform.localScale.x * transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        HeatExchange();
    }

    public void HeatExchange()
    {
        
        var tempDiff = temperature1.temperature - temperature2.temperature;
        //Debug.Log(tempDiff.ToString());
        double power = surfaceArea * uValue * tempDiff / 1000;
        //Debug.Log(power.ToString());
        temperature1.temperature -= (power * Time.deltaTime * Variables.Instance.timeScale) / (shc * temperature1.mass);
        temperature2.temperature += (power * Time.deltaTime * Variables.Instance.timeScale) / (shc * temperature2.mass);
    }
}
