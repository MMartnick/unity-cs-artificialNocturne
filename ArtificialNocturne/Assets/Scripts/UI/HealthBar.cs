using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HealthBar : MonoBehaviour
{

    public Slider Health;
    public Text CurrentText;

    public float CurrentHP;
    public float HP;

    // Start is called before the first frame update
    void Start()
    {
      CurrentHP = GetComponent<CharacterData>().CurrentHP;
        HP = GetComponent<CharacterData>().HP;
    }

    // Update is called once per frame
    void Update()
    {

        // CurrentText = HealthHud.GetComponent<Text>();


        CurrentHP = GetComponent<CharacterData>().CurrentHP;
        HP = GetComponent<CharacterData>().HP;
        Health.value = CurrentHP;

        CurrentText.text = CurrentHP.ToString();


    }
}
