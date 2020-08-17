using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Character : MonoBehaviour
{
    // General values

    [SerializeField] private bool isAI;
    public bool IsAI
    {
        get { return isAI; }
        set { isAI = value; }
    }

    //public Rigidbody2D thisRigidBody;
    public Animator animator;

    // Character base attributes ===========================================================
    private string charName;
    private string charType;
    private float hp;
    private float mp;
    private float currentHp;
    private float currentMp;
    private float strength;
    private float dexterity;
    private float vitality;
    private float magic;
    private float spirit;
    private float luck; // do later

    [SerializeField] private GameObject dropItem;

    [SerializeField] private float knockBack;
    [SerializeField] private float chaseRadius;
    [SerializeField] private float attackRadius;
    public int jump;

    private Transform target;
    private Vector3 velocity;

    // weapon attributes ==============================================================
    private float weaponStrength = 6;
    private float armorVitality;
    private float weaponMagic;
    private float armorSpirit;
    private float weaponSuccessRate; // do later
    private float armorSuccessRate; // do later

    // Base + weapon attributes ==============================================================
    private float attack;
    private float attackPer; // do later
    private float defense;
    private float defensePer; // do later
    private float magicAtk;
    private float magicDef;
    private float magicDefPer; // do later


    // character individual skills ====================================================
    public delegate void abilityDelegate1();
    public delegate void abilityDelegate2();
    public delegate void abilityDelegate3();
    public delegate void abilityDelegate4();

    abilityDelegate1 ability1;
    abilityDelegate2 ability2;
    abilityDelegate3 ability3;
    abilityDelegate4 ability4;


    // State manager
    private PlayerState currentState;



    // Start is called before the first frame update ==================================
    public void Start()
    {
        currentHp = hp;
        currentMp = mp;

        attack = strength + dexterity;
        defense = vitality + armorVitality;
        magicAtk = magic + weaponMagic;
        magicDef = spirit + armorSpirit;

        if (isAI)
        {
            IfIsEnemy();
        }

        if (!isAI)
        {
            IfIsPlayer();
        }
    }


    // Update is called once per frame
    public void Update()
    {

    }


    // Calls components that are universal to all enemy characters
    private void IfIsEnemy()
    {
        gameObject.AddComponent<Damage>();

    
    }


    // Calls components that are universal to all player characters
    private void IfIsPlayer()
    {
        gameObject.AddComponent<Damage>();

    }

    // Character base attributes get/set ======================================================
    public string CharName
    {
        get { return charName; }
        set { charName = value; }
    }

    public string CharType
    {
        get { return charType; }
        set { charType = value; }
    }

    public float HP
    {
        get { return hp; }
        set { hp = value; }
    }

    public float MP
    {
        get { return mp; }
        set { mp = value; }
    }

    public float CurrentHP
    {
        get { return currentHp; }
        set { currentHp = value; }
    }

    public float CurrentMP
    {
        get { return currentMp; }
        set { currentMp = value; }
    }

    public float Strength
    {
        get { return strength; }
        set { strength = value; }
    }

    public float Dexterity
    {
        get { return dexterity; }
        set { dexterity = value; }
    }

    public float Vitality
    {
        get { return vitality; }
        set { vitality = value; }
    }

    public float Spirit
    {
        get { return spirit; }
        set { spirit = value; }
    }

    public float Magic
    {
        get { return magic; }
        set { magic = value; }
    }

    public float Luck
    {
        get { return luck; }
        set { luck = value; }
    }

    public float KnockBack
    {
        get { return knockBack; }
        set { knockBack = value; }
    }

    public float ChaseRadius
    {
        get { return chaseRadius; }
        set { chaseRadius = value; }
    }

    public float AttackRadius
    {
        get { return attackRadius; }
        set { attackRadius = value; }
    }

    public Transform Target
    {
        get { return target; }
        set { target = value; }
    }

    public Vector3 Velocity
    {
        get { return velocity; }
        set { velocity = value; }
    }

    public GameObject DropItem
    {
        get { return dropItem; }
        set { dropItem = value; }
    }
}
