using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightDebug : MonoBehaviour
{

    public GameObject RangText;
    public GameObject SpotText;
    public GameObject IntText;

    public static float RangeMult = 1;
    public static float SpotMult = 122;
    public static float IntenseMult = 1;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RangText.GetComponent<Text>().text = RangeMult.ToString();
        SpotText.GetComponent<Text>().text = SpotMult.ToString();
        IntText.GetComponent<Text>().text = IntenseMult.ToString();
    }



    public void IncRange()
    {
        RangeMult++;
    }

    public void DecRange()
    {
        RangeMult--;
    }

    public void IncSpot()
    {
        SpotMult++;
    }

    public void DecSpot()
    {
        SpotMult--;
    }

    public void IncInt()
    {
        IntenseMult++;
    }

    public void DecInt()
    {
        IntenseMult--;
    }
}
