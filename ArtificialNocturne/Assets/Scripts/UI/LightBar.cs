using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

// This script goes on the light
public class LightBar : MonoBehaviour
{
    public Slider Light;
    public Text LightText;
    public float CurrentLP;


    public float DisplayLight;
    public float MaxLight = 500;
    public float LightRange;

    public float RangeMult;
    public float SpotMult;
    public float IntenseMult;



    void Start()
    {
        InputSystem.EnableDevice(LightSensor.current);
        var StartLight = LightSensor.current.lightLevel.ReadValue();
        DisplayLight = (float)StartLight;

        this.GetComponent<Light>().range = (float)DisplayLight;
    }

    void Update()
    {
        // Debug
        RangeMult = 2; // LightDebug.RangeMult;
        //SpotMult = LightDebug.SpotMult;
        IntenseMult = 68; // LightDebug.IntenseMult;


        if (LightSensor.current.enabled)
        {
            var CurrentLight = LightSensor.current.lightLevel.ReadValue();

            if (CurrentLight < 200)
            {
                DisplayLight = 250;
            }
            else if (CurrentLight > 5000)
            {
                DisplayLight = 5000;
            }
            else
            { 
                DisplayLight = (float)CurrentLight;
            }
        }
        Light.value = (float)DisplayLight / 10;
        this.GetComponent<Light>().range = (float)DisplayLight / RangeMult;
       // this.GetComponent<Light>().spotAngle = (float)DisplayLight / SpotMult;
        this.GetComponent<Light>().intensity = (float)DisplayLight / IntenseMult;

        CurrentLP = DisplayLight / 10;
        LightText.text = CurrentLP.ToString();

        //this.GetComponent<Light>().intensity = (float)DisplayLight;
        Debug.Log("Light " + LightSensor.current.lightLevel.ReadValue());

    }


    // 32000 Lux is the max my device will take in
    /*

            this.GetComponent<Light>().range = (float) DisplayLight / 6.8f;
        this.GetComponent<Light>().spotAngle = (float) DisplayLight / 94;
        this.GetComponent<Light>().intensity = (float) DisplayLight / 6.8f;     */
}
