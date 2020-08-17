using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public GameObject player;
    private PolygonCollider2D weaponCollider;
    private Vector3 weaponPosition;
    public float X;
    public float Y;
    public Vector3 curVel;
    public Vector3 prevLoc;

    // Start is called before the first frame update
    void Start()
    {
        // init sword disabled
   
        X = player.transform.position.x;
       Y = player.transform.position.y;
     

    }

    // Update is called once per frame
    void Update()
    {
        // enable sword if attack fuction called in playerMovement or enemyMovement
        X = player.transform.position.x;
        Y = player.transform.position.y;

        FindDirection();



    }

    void FindDirection()
    {
        curVel = new Vector3((player.transform.position.x - prevLoc.x) / Time.deltaTime, (player.transform.position.y - prevLoc.y) / Time.deltaTime, transform.position.z);
        Debug.Log("curVel = " + curVel);

        if (curVel.y > 0)
        /*{
            // it's moving up
            velocityY = new Vector3(transform.position.x, transform.position.y + 25, transform.position.z);
        }
        else
        {
            // it's moving down
            velocityY = new Vector3(transform.position.x, transform.position.y - 25, transform.position.z);
        }*/

        if (curVel.x > 0)
        {
            // it's moving right
            transform.position = new Vector3(X + 1.2355f, Y + 0.187f, transform.position.z);
        }
        else
        {
            // it's moving left
            transform.position = new Vector3(X - 1.2355f, Y + 0.187f, transform.position.z);
        }



        prevLoc = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        Debug.Log("prevLoc = " + prevLoc);
    }


}
