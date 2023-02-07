using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class mqttController : MonoBehaviour
{

    public string nameController = "Controller 1";
    //public string tagOfTheMQTTReceiver = "";
    public mqttReceiverAuthFromFile _eventSender;
    // Start is called before the first frame update
    void Start()
    {
        //_eventSender = GameObject.FindGameObjectsWithTag(tagOfTheMQTTReceiver)[0].gameObject.GetComponent < mqttReceiver>();
        _eventSender.OnMessageArrived += OnMessageArrivedHandler;
    }

    private void OnMessageArrivedHandler(string newMsg) {
        this.GetComponent<TextMeshPro>().text = newMsg;
        Debug.Log("Event Fired. The message, from Object " + nameController + " is = " + newMsg);
    }
}
