using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Create AI states that give it life
// Sleep
// Idle - Done
// Attacking - Done
// Delay - 
// Damaged - Done
// Death - Done

public enum GoblinState
{
    sleep,
    idle,
    chase,
    attack,
    delay,
    damaged,
    death
}

public class GoblinController : MonoBehaviour
{

    // State manager
    public GoblinState currentState;

    // General values
    private Rigidbody2D thisRigidBody;
    public Animator thisAnimator;
    public GameObject dropItem;

    // Character attributes
    public float strength;
    public float hp = 10;
    public float dexterity;
    public int jump;

    // Movement values
    private Vector3 change;
    public bool setChase;

    // Idle state values
    public Vector3 startPos;
    public float randX;
    public float randY;
    public bool idle;

    // Targeting values
    public Transform target;
    public Transform player;
    public Transform idleTarget;

    [SerializeField] private float chaseRadius;
    [SerializeField] private float attackRadius;
    public bool attacking;

    // Damage value
    public bool damaged;

    // Knock back values
    public Vector3 velocity;
    private Vector3 velocityY;
    private Vector3 velocityX;
    private Vector3 prevLoc;
    private Vector3 currentLoc;
    private float knockBack;


    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;

        player = FindObjectOfType<Nex>().transform;

        strength = GetComponent<CharacterData>().Strength;
        dexterity = GetComponent<CharacterData>().Dexterity;
        chaseRadius = GetComponent<CharacterData>().ChaseRadius;
        attackRadius = GetComponent<CharacterData>().AttackRadius;
        dropItem = GetComponent<CharacterData>().DropItem;

        thisAnimator = GetComponent<Animator>();
        thisRigidBody = GetComponent<Rigidbody2D>();

        prevLoc = this.transform.position;

        //idle = false;
        setChase = false;
    }

    // Update is called once per frame
    void Update()
    {

      //  Debug.Log(currentState + " is the current state. ");
        currentLoc = this.transform.position;
        change = Vector3.zero;

        hp = GetComponent<Damage>().newHp;
        damaged = GetComponent<Damage>().isDamaged;
        dexterity = GetComponent<CharacterData>().Dexterity;
        dropItem = GetComponent<CharacterData>().DropItem;

        target = FindObjectOfType<Nex>().transform;

        CheckDistance();
        CheckHealth();
        CheckDamage();

        // Sets behaviour for sleep state
        if (currentState == GoblinState.sleep)
        {
            prevLoc = this.transform.position;
        }

        // Sets behaviour for idle state
        if (currentState == GoblinState.idle)
        {
            setChase = false;
            prevLoc = this.transform.position;

            thisAnimator.SetBool("moving", false);
        }

        // Sets behaviour for chase state
        if (currentState == GoblinState.chase)
        {
            setChase = true;
            currentLoc = this.transform.position;
            thisAnimator.SetBool("moving", true);
            UpdateMovementAnim();  
        }
        else
        {
            setChase = false;
        }

        // Sets behaviour for attack state
        if (currentState == GoblinState.attack)
        {
            prevLoc = this.transform.position;
            StartCoroutine(AiAtkManager());
        }


        // Sets behaviour for delay state
        if (currentState == GoblinState.delay)
        {
            prevLoc = this.transform.position;
            StartCoroutine(AiDelayManager());
        }

        // Sets behaviour for damaged state
        if (currentState == GoblinState.damaged)
        {
            prevLoc = this.transform.position;
            StartCoroutine(AiDmgManager());
        }

        // Sets behaviour for death state
        if (currentState == GoblinState.death)
        {
            StartCoroutine(AiDeathManager());
            
        }
    }


    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {

            velocity = new Vector3(velocityX.x, velocityY.y, transform.position.z);
            Rigidbody2D rig = col.gameObject.GetComponent<Rigidbody2D>();
            if (rig == null) { return; }
            rig.AddForce(velocity * knockBack);

        }
        if (1 == 1)
        {
            // This will be damage infliction
        }
    }

    void UpdateMovementAnim()
    {
        change.x = currentLoc.x - prevLoc.x;
        change.y = currentLoc.y - prevLoc.y;

        if (change != Vector3.zero)
        {
            thisAnimator.SetFloat("moveX", change.x);
            thisAnimator.SetFloat("moveY", change.y);
        }
    }


    // All checks  ==========================================================================================================================================

    void CheckDistance()
    {
        if
          ((Vector3.Distance(target.position, transform.position) <= attackRadius) && (currentState != GoblinState.attack))
        {
            
            currentState = GoblinState.attack;
            setChase = false;
        }

        if (Vector3.Distance(target.position, transform.position) <= chaseRadius
            && Vector3.Distance(target.position, transform.position) >= attackRadius)
        {
            
            currentState = GoblinState.chase;
            setChase = true;
        }

        if (Vector3.Distance(target.position, transform.position) >= chaseRadius
            && Vector3.Distance(target.position, transform.position) >= attackRadius)
        {
            currentState = GoblinState.idle;
            setChase = false;
            
        }

    }

    void CheckHealth()
    {
        if (hp <= 0)
        {
            currentState = GoblinState.death;
        }
    }

    void CheckDamage()
    {
        if (damaged == true)
        {
            currentState = GoblinState.damaged;
        }
    }


    // All State managers =================================================================================================================================

    IEnumerator AiAtkManager()
    {
        attacking = true;
        thisAnimator.SetBool("attacking", true);
        yield return new WaitForSeconds(1f);
        thisAnimator.SetBool("attacking", false);
        currentState = GoblinState.delay;
    }

    IEnumerator AiDelayManager()
    {
        thisAnimator.SetBool("moving", false);
        thisAnimator.SetBool("attacking", false);
        yield return new WaitForSeconds(2f);
        currentState = GoblinState.idle;
        attacking = false;
    }

    IEnumerator AiDmgManager()
    {

        thisAnimator.SetBool("damage", true);
        yield return new WaitForSeconds(2f);
        thisAnimator.SetBool("damage", false);
        currentState = GoblinState.idle;
        damaged = false;

    }

    IEnumerator AiDeathManager()
    {
        thisAnimator.SetBool("dead", true);
        yield return new WaitForSeconds(5f);
        Instantiate(dropItem, new Vector3(currentLoc.x, currentLoc.y, currentLoc.z), Quaternion.identity);
        Destroy(transform.root.gameObject);
    }

}