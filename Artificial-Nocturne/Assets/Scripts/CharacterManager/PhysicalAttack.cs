using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicalAttack : MonoBehaviour
{

    // General values
    private Rigidbody2D playerRigidBody;
    private Animator animator;

    // Attack values
    private bool firstButtonPress = false;
    private bool secondButtonPress = false;
    private bool thirdButtonPress = false;
    private float comboTimer = 0.5f;
    private int currentComboState = 1;

    // Player attributes
    public float strength;
    public bool mobileAtk;


    // Start is called before the first frame update
    void Start()
    {

        playerRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        animator = GetComponent<Animator>();
        strength = GetComponent<CharacterData>().Strength;

        if (mobileAtk == true)
        {
            StartCoroutine(AtkManager());
        }

        if (Input.GetButtonDown("attack"))//&& currentState != PlayerState.attack)
        {
            StartCoroutine(AtkManager());
        }
    }

    void Attack()
    {
        animator.SetBool("AtkPressed", true);
    }

    public void MblAttack()
    {

        mobileAtk = true;
    }

    void AtkStateUpdate()
    {
        currentComboState++;
        animator.SetBool("AtkPressed", false);
        //currentState = PlayerState.walk;
        // increments combo state by 1
    }

    void ResetAtkState()
    {
        currentComboState = 1;
        animator.SetBool("AtkPressed", false);
        //currentState = PlayerState.walk;
        //resets combo state to it's default value of 1
        mobileAtk = false;
    }

    public IEnumerator AtkManager()
    {

        /*  if (currentComboState == 2 && firstButtonPress == true)
          {
              animator.SetBool("AtkPressed", true);

              //currentState = PlayerState.attack;
              Debug.Log("2 hits");
              firstButtonPress = false;
              yield return new WaitForSeconds(.3f);
              ResetAtkState();
          }*/

        if (currentComboState == 1)
        {
            animator.SetBool("AtkPressed", true);
            //currentState = PlayerState.attack;
            Debug.Log("1 hit");
            firstButtonPress = true;
            yield return new WaitForSeconds(0.3f);
            AtkStateUpdate();
            ResetAtkState();
            //Invoke("ResetAtkState", comboTimer);
        }


    }
}
