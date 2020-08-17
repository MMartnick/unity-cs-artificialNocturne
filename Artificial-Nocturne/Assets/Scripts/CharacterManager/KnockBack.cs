using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBack : MonoBehaviour
{
    public string charType;
    public float enemyHealth;
    public float enemyDamage;
    public float enemyNewHealth;
    public float knockBack;
    public Vector3 velocity;

    private void Start()
    {
        charType = GetComponentInParent<CharacterData>().CharType;
        enemyDamage = GetComponentInParent<CharacterData>().Strength;
        knockBack = GetComponentInParent<CharacterData>().KnockBack;
        velocity = GetComponentInParent<CharacterData>().Velocity;
    }

    void Update()
    {
        velocity = GetComponentInParent<CharacterData>().Velocity;
    }



    void OnCollisionEnter2D (Collision2D col) {

        if (col.gameObject.CompareTag(charType) && GetComponentInParent<CharacterData>().CharType == charType)
        {
            col.gameObject.GetComponent<Damage>().damage = 0;
            Debug.Log(col.gameObject.GetComponent<Damage>().damage);
            Rigidbody2D rig = col.gameObject.GetComponent<Rigidbody2D>();
            rig.AddForce(velocity * 20f);
        } else

        if (col.gameObject.CompareTag("Enemy") && charType == "Player"  ||
           col.gameObject.CompareTag("Player") && charType == "Enemy") {
           enemyHealth = col.gameObject.GetComponent<CharacterData>().CurrentHP;
            col.gameObject.GetComponent<Damage>().damage = enemyDamage;
            Debug.Log(col.gameObject.GetComponent<Damage>().damage);
            col.gameObject.GetComponent<Damage>().DmgFunct();
            //Debug.Log("Col");
            Rigidbody2D rig = col.gameObject.GetComponent<Rigidbody2D>();
            if(rig == null) { return;}
            rig.AddForce( velocity * knockBack); 
        }
    }
}