using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIWriter : MonoBehaviour
{
    public Temperature writtenTemperature1;
    public Temperature outsideTemperature;
    [SerializeField]
    private TextMeshProUGUI outsideTempText;
    [SerializeField]
    private TextMeshProUGUI insideTemp1Text;
    public Temperature writtenTemperature2;
    [SerializeField]
    private TextMeshProUGUI insideTemp2Text;
    public Temperature writtenTemperature3;
    [SerializeField]
    private TextMeshProUGUI insideTemp3Text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        WriteTempUiCanvas();
    }

    private void WriteTempUiCanvas()
    {
        outsideTempText.text = outsideTemperature.temperature.ToString("F2") + "°C";
        insideTemp1Text.text = writtenTemperature1.temperature.ToString("F3") + "°C";
        insideTemp2Text.text = writtenTemperature2.temperature.ToString("F3") + "°C";
        insideTemp3Text.text = writtenTemperature3.temperature.ToString("F3") + "°C";
    }


}
