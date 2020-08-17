using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public enum PlayerState
{
    walk,
    attack,
    interact
}
*/
public class PlayerMoverment : MonoBehaviour
{
     
//    // General values
//    private Rigidbody2D playerRigidBody;
//    private Animator animator;
// 
//    // Player attributes
//    public float strength;
//    public float hp;
//    public float dexterity;
//    public int jump;
// 
//    // Movement values
//    private Vector3 change;
// 
// 
//    // Attack values
//    private bool firstButtonPress = false;
//    private bool secondButtonPress = false;
//    private bool thirdButtonPress = false;
//    private float comboTimer = 0.5f;
//    private int currentComboState = 1;
// 
//    private float damageIntake;
// 
//    // State manager
//    private PlayerState currentState;
// 
//    // Mobile
//    public bool mobileAtk;
// 
//    public void Start()
//    {
//        hp = GetComponent<CharacterData>().CurrentHP;
//        strength = GetComponent<CharacterData>().Strength;
//        dexterity = GetComponent<CharacterData>().Dexterity;
//        animator = GetComponent<Animator>();
//        playerRigidBody = GetComponent<Rigidbody2D>();
//    }
// 
// 
//    public void Update()
//    {
//        playerRigidBody = GetComponent<Rigidbody2D>();
// 
//        currentState = PlayerState.walk;
//        change = Vector3.zero;
//        change.x = Input.GetAxisRaw("Horizontal");
//        change.y = Input.GetAxisRaw("Vertical");
// 
// 
//        if (mobileAtk == true)
//        {
//            StartCoroutine(AtkManager());
//        }
// 
//        if (Input.GetButtonDown("attack") && currentState != PlayerState.attack)
//        {
//            StartCoroutine(AtkManager());
//        }
// 
//        if (currentState == PlayerState.walk)
//        {
//            UpdatePlayerMoverment();
//        }
// 
//    }
// 
//    /* ===== Movement ===============================================================================================*/
//    void UpdatePlayerMoverment()
//    {
//        if (change != Vector3.zero)
//        {
//            Movement();
//            animator.SetFloat("moveX", change.x);
//            animator.SetFloat("moveY", change.y);
//            animator.SetBool("moving", true);
//        }
//        else
//        {
//            animator.SetBool("moving", false);
//        }
//    }
// 
//    void Movement()
//    {
//        playerRigidBody.MovePosition(transform.position + change * dexterity * Time.deltaTime);
// 
//    }
// 
//    /* ===== Movement ===============================================================================================*/
// 
//    /* ===== Attacking ===============================================================================================*/
// 
//    public void MblAttack()
//    {
// 
//        mobileAtk = true;
//    }
// 
//    void Attack()
//    {
//        animator.SetBool("AtkPressed", true);
//    }
// 
// 
//    void AtkStateUpdate()
//    {
//        currentComboState++;
//        animator.SetBool("AtkPressed", false);
//        mobileAtk = false;
//        currentState = PlayerState.walk;
//        // increments combo state by 1
//    }
// 
//    void ResetAtkState()
//    {
//        currentComboState = 1;
//        animator.SetBool("AtkPressed", false);
//        currentState = PlayerState.walk;
//        //resets combo state to it's default value of 1
//    }
// 
//    IEnumerator AtkManager()
//    {
// 
//        /*   if (currentComboState == 2 && firstButtonPress == true)
//           {
//               animator.SetBool("AtkPressed", true);
// 
//               currentState = PlayerState.attack;
//               Debug.Log("2 hits");
//               firstButtonPress = false;
//               yield return new WaitForSeconds(.33f);
//               ResetAtkState();
//           }  */
// 
//        if (currentComboState == 1)
//        {
//            animator.SetBool("AtkPressed", true);
//            currentState = PlayerState.attack;
//            Debug.Log("1 hit");
//            firstButtonPress = true;
//            yield return new WaitForSeconds(.33f);
//            AtkStateUpdate();
//            ResetAtkState(); // temporary
// 
//            Invoke("ResetAtkState", comboTimer);
//        }
// 
// 
// 
// 
//    }
// 
     /* ===== Attacking ===============================================================================================*/
}
