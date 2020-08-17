using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleTest : MonoBehaviour
{

    // Idle state values
    public Vector3 startPos;
    public Vector3 randX;
    public Vector3 randY;
    public bool idle;

    public float dexterity = 300;
    // Start is called before the first frame update
    void Start()
    {
        startPos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {


        if (idle == false)
        {
            StartCoroutine(AiIdleManager());
        }
    }

    void IdleWalk()
    {
        var randXNeg = Random.Range(1, 4);
        var randYNeg = Random.Range(1, 4);

        if (randXNeg <= 2)
        {
            randX = new Vector3(-900000.00f, 0, 0);
        } else if (randXNeg >= 3)
        {
            randX = new Vector3(900000.00f, 0, 0);
        }

        if (randYNeg <= 2)
        {
            randY = new Vector3(0, -900000.00f, 0);
        }
        else if (randYNeg >= 3)
        {
            randY = new Vector3(0, 900000.00f, 0);
        }

        var test = new Vector3(randX.x + transform.position.x, randY.y + transform.position.y, 0);
        transform.position = Vector3.MoveTowards(transform.position, test, dexterity * Time.deltaTime);
        //thisAnimator.SetBool("moving", true);
        //UpdateMovementAnim();
    }

    IEnumerator AiIdleManager()
    {
        idle = true;
        IdleWalk();
        yield return new WaitForSeconds(5f);
        //thisAnimator.SetBool("moving", false);
        transform.position = Vector3.MoveTowards(transform.position, startPos, dexterity * Time.deltaTime);
       // thisAnimator.SetBool("moving", true);
        //UpdateMovementAnim();
        yield return new WaitForSeconds(5f);
        //thisAnimator.SetBool("moving", false);
        idle = false;

    }
}
