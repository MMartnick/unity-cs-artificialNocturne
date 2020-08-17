using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    idle,
    walk,
    attack,
    interact
}

public class JoyMovement : MonoBehaviour
{
    public float dexterity;
    Animator animator;
    Vector2 change;
    Rigidbody2D playerRigidBody;

    public Joystick Joystick;

    private bool moving;
    private float vertical;
    private float horizontal;

    // State manager
    private PlayerState currentState;


    // Start is called before the first frame update
    void Start()
    {
        playerRigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        dexterity = GetComponent<CharacterData>().Dexterity;


        vertical = Joystick.Vertical;
        horizontal = Joystick.Horizontal;

        bool hasVerticalMovement = !Mathf.Approximately(vertical, 0f);
        bool hasHorizontalMovement = !Mathf.Approximately(horizontal, 0f);

        moving = hasHorizontalMovement || hasVerticalMovement;


        // Sets state

        if (moving == true)
        {
            currentState = PlayerState.walk;
        }
        else
        {
            currentState = PlayerState.idle;
        }



        // State functionality

        if (currentState == PlayerState.walk)
        {
            UpdatePlayerMoverment(moving, change);
            change = new Vector2(horizontal, vertical);
            change.Normalize();
        }

        if (currentState == PlayerState.idle)
        {
            animator.SetBool("moving", false);

        }

    }

    private void UpdatePlayerMoverment(bool walking, Vector2 direction)
    {

        if (change != Vector2.zero)
        {
            Movement();
            animator.SetFloat("moveX", change.x);
            animator.SetFloat("moveY", change.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }

        void Movement()
        {
            playerRigidBody.MovePosition(playerRigidBody.position + change * dexterity * Time.deltaTime);

        }

    }
}

