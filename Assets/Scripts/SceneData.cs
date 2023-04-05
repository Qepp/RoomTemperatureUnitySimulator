using Csv;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class SceneData : MonoBehaviour
{
    [SerializeField]
    List<string> dataNames = new List<string>();
    [SerializeField]
    Temperature outsideTemp;
    [SerializeField]
    Temperature roomTemp;

    [Tooltip("How often is data point saved in seconds")]
    public int timespan;

    public List<timedData> dataPoints = new List<timedData>();

    private float timer = 0;

    private Variables variables;

    [System.Serializable]
    public class timedData
    {
        public double time;
        public double powerUsed;
        public double roomTemperature;
        public double outsideTemp;

        public timedData(double newTime, double newPowerUsed, double newRoomTemp, double newOutsideTemp)
        {
            time = newTime;
            powerUsed = newPowerUsed;
            roomTemperature = newRoomTemp;
            outsideTemp = newOutsideTemp;
        }
        
    }

    private void Awake()
    {
        variables = GetComponent<Variables>();
    }

    // Start is called before the first frame update
    void Start()
    {
        dataPoints.Add(new timedData(0, 0, roomTemp.temperature, outsideTemp.temperature));

    }

    private void OnDestroy()
    {
        
    }

    void SaveCsvFile()
    {
        List<List<string>> lists = new List<List<string>>();
        foreach (var thing in dataPoints)
        {
            lists.Add(new List<string>()
            {
                thing.time.ToString(),
                thing.powerUsed.ToString(),
                thing.roomTemperature.ToString(),
                thing.outsideTemp.ToString()
            });
        }

        var rows = lists.Select(a => a.ToArray()).ToArray();

        var columnNames = dataNames.ToArray();
        //string[][] rowss = new string[dataPoints.Count][];
        //var rows = new[]
        //{
        //    new [] { dataPoints[0].time.ToString(),  dataPoints[0].powerUsed.ToString(), dataPoints[0].roomTemperature.ToString()},
        //    new [] { "1", "Jane Doe" }
        //};
        var csv = CsvWriter.WriteToText(columnNames, rows, ',');
        File.WriteAllText(Application.dataPath+"SceneData.csv", csv);
        Debug.Log("File saved");
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= timespan)
        {
            Debug.Log("New Data point added");
            dataPoints.Add(new timedData(variables.SecondsGone, variables.EnergyUsedKWh, roomTemp.temperature, outsideTemp.temperature));
            timer -= timespan;
            SaveCsvFile();
        }
        
        timer += Time.deltaTime * variables.timeScale;
        
    }
}
