using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BasicLight : MonoBehaviour
{

    public float StartLux;
    public float CurrentLux;

    void Start()
    {
        InputSystem.EnableDevice(LightSensor.current);
        StartLux = LightSensor.current.lightLevel.ReadValue();
    }

    void Update()
    {
        if (LightSensor.current.enabled)
        {
            CurrentLux = LightSensor.current.lightLevel.ReadValue();
        }
    }
}
