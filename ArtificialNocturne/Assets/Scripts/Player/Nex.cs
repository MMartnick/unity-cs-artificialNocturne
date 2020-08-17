using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nex : Character
{

    public Nex()
    {
        CharName = "Nex";
        CharType = "Player";
        HP = 500;
        MP = 600;
        CurrentHP = HP;
        CurrentMP = MP;
        Strength = 10;
        Dexterity = 100;
        Vitality = 6;
        Magic = 6;
        Spirit = 9;
        Luck = 8;

        KnockBack = 120;
        ChaseRadius = 50;
        AttackRadius = 1;
        IsAI = false;
    }

    // Start is called before the first frame update
    new void Start()
    {
        // Here we set character data for all following components to retrieve
        gameObject.AddComponent<CharacterData>();
        GetComponent<CharacterData>().SetCharData(
            CharName, CharType, HP, MP, CurrentHP, CurrentMP, Strength, Dexterity,
            Vitality, Magic, Spirit, Luck, KnockBack,
            ChaseRadius, AttackRadius
            );

        // Additional components are placed here

        // Base should be called after all data is set
        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();
    }


    void fire()
    {
        Debug.Log("fire");
    }

    void water()
    {
        Debug.Log("water");

    }

    void earth()
    {
        Debug.Log("earth");

    }

    void wind()
    {
        Debug.Log("wind");

    }


}
