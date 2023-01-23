using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIWriter : MonoBehaviour
{
    public Temperature writtenTemperature;
    [SerializeField]
    private TextMeshProUGUI outsideTempText;
    [SerializeField]
    private TextMeshProUGUI insideTempText;
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
        outsideTempText.text = writtenTemperature.outsideTemp.ToString("F2") + "°C";
        insideTempText.text = writtenTemperature.temperature.ToString("F3") + "°C";
    }


}
