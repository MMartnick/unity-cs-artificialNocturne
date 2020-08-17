using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class CharacterData : MonoBehaviour
{
    [SerializeField] public string CharName;
    [SerializeField] public string CharType;

    [SerializeField] public float HP;
    [SerializeField] public float MP;
    [SerializeField] public float CurrentHP;
    [SerializeField] public float CurrentMP;

    [SerializeField] public float Strength;
    [SerializeField] public float Dexterity;
    [SerializeField] public float Vitality;
    [SerializeField] public float Magic;
    [SerializeField] public float Spirit;
    [SerializeField] public float Luck;

    [SerializeField] public float KnockBack;
    [SerializeField] public float ChaseRadius;
    [SerializeField] public float AttackRadius;

    [SerializeField] public GameObject DropItem;

    public Vector3 Velocity;
    public Transform Target;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CurrentHP = GetComponent<Damage>().newHp;

        if (CurrentHP <= 0 && CharType == "Player")
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    // Constructor to set data
    public void SetCharData(string charName, string charType,
        float hp, float mp,
        float currentHp, float currentMp,
        float strength, float dexterity,
        float vitality, float magic,
        float spirit, float luck,
        float knockBack, float chaseRadius,
        float attackRadius
        )
    {
        CharName = charName;
        CharType = charType;
        HP = hp;
        MP = mp;
        CurrentHP = currentHp;
        CurrentMP = currentMp;
        Strength = strength;
        Dexterity = dexterity * 10;
        Vitality = vitality;
        Magic = magic;
        Spirit = spirit;
        Luck = luck;

        KnockBack = knockBack * 100;
        ChaseRadius = chaseRadius * 10;
        AttackRadius = attackRadius;
    }

    public void AtkSet(Transform target, Vector3 velocity, GameObject dropItem)
    {
        Target = target;
        Velocity = velocity;
        DropItem = dropItem;
    }
}