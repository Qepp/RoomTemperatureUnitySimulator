using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnAwake : MonoBehaviour
{
    private void Awake()
    {
        Debug.Log("Awake kutsuttu");
        gameObject.SetActive(false);
    }
    private void OnEnable()
    {
        Debug.Log("OnEnable kutsuttu");
    }
}
