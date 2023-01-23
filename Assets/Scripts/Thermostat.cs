using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thermostat : MonoBehaviour
{
    [Header("Thermostat location")]
    public Transform locationObject;
    [Tooltip("If locationObject empty generate new empty gameobject to location")]
    public Vector3 location;

    private Vector3 lastPos;

    [SerializeField]
    private double targetTemperature;

    public thermostatType dropDown = new();

    private List<GameObject> rooms = new List<GameObject>();
    private Temperature closestRoom;

    [SerializeField]
    private Heater temperChanger;

     public enum thermostatType
    {
        heater,
        cooler,
        mixed
    };
    private void Awake()
    {
        if (locationObject == null)
        {
            locationObject = new GameObject().transform;
            locationObject.position = location;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rooms.AddRange(GameObject.FindGameObjectsWithTag("Room"));
        lastPos = locationObject.position;
        GameObject closeBy = rooms[0];
        foreach (GameObject room in rooms)
        {
            if (Vector3.Distance(room.transform.position, lastPos) < Vector3.Distance(closeBy.transform.position, lastPos))
            {
                closeBy = room;
            }
        }
        closestRoom = closeBy.GetComponent<Temperature>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lastPos != locationObject.position)
        {
            GameObject closeBy = closestRoom.gameObject;
            foreach (GameObject room in rooms)
            {
                if (Vector3.Distance(room.transform.position, lastPos) < Vector3.Distance(closestRoom.transform.position, lastPos))
                {
                    closeBy = room;
                }
            }
            closestRoom = closeBy.GetComponent<Temperature>();
            lastPos = locationObject.position;
        }

        if (thermostatType.heater == dropDown)
        {
            if (closestRoom.temperature < targetTemperature)
            {
                temperChanger.EnableHeater();
            }
            else
            {
                temperChanger.DisableHeater();
            }
        }
    }
}
