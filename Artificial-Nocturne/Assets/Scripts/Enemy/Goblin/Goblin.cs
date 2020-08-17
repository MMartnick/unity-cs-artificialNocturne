using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Goblin : Character
{
    public Goblin()
    {
        CharName = "Goblin1";
        CharType = "Enemy";
        HP = 80;
        MP = 800;
        CurrentHP = HP;
        CurrentMP = MP;
        Strength = 10;
        Dexterity = 30;
        Vitality = 6;
        Magic = 6;
        Spirit = 9;
        Luck = 8;

        KnockBack = 1000;
        ChaseRadius = 150;
        AttackRadius = 300;  // 300 is the bare minimum close combat attack radius. 
        IsAI = true;

        
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

        // Adding the character controller after data populates but before pathfinding
        gameObject.AddComponent<GoblinController>();

        //get and set the target and velocity for the knockback script
        Velocity = GetComponent<GoblinController>().velocity;
        Target = GetComponent<GoblinController>().target;

        

        // Additional components are placed here
        gameObject.AddComponent<Unit>();
        // Base should be called after all data is set
        base.Start();
    }

    // Update is called once per frame
    new void Update()
    {
        base.Update();

        Velocity = GetComponent<GoblinController>().velocity;
        Target = GetComponent<GoblinController>().target;

        GetComponent<CharacterData>().AtkSet(Target, Velocity, DropItem);
    }

    // Character exclusive abilities
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


    private void OnDestroy()
    {
      

    }
}

