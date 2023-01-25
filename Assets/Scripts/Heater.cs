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
    private bool heaterOn = false;
    [SerializeField]
    private float elapsedTime = 0;
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
        if (!heaterOn)
        {
            StopAllCoroutines();
            StartCoroutine(WarmingHeater());
            heaterOn = true;
            onLight.color = Color.green;
        }
    }

    public void DisableHeater()
    {
        if (heaterOn)
        {
            StopAllCoroutines();
            StartCoroutine(CoolingHeater());
            onLight.color = Color.red;
            heaterOn = false;
        }
    }

    IEnumerator WarmingHeater()
    {
        

        while (elapsedTime < warmUpTime)
        {
            elapsedTime += Time.deltaTime * Variables.Instance.timeScale;
            power = Mathf.Lerp(0, maxPower, elapsedTime / warmUpTime);
            
            yield return null;
        }
        elapsedTime = warmUpTime;
    }
    IEnumerator CoolingHeater()
    {
        

        while (elapsedTime > 0)
        {
            elapsedTime -= Time.deltaTime * Variables.Instance.timeScale;
            power = Mathf.Lerp(0, maxPower, elapsedTime / warmUpTime);

            yield return null;
        }
        elapsedTime = 0;
    }

    private void HeatAir()
    {
        airTemp.HeatByWatts(power);
    }
}
