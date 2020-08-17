using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float startHp;
    public float newHp;
    public float damage;
    public bool isDamaged;


    // Start is called before the first frame update
    void Start()
    {
        startHp = GetComponent<CharacterData>().CurrentHP;
        newHp = startHp;
    }

    // Update is called once per frame
    void Update()
    {

        if (newHp <= 0)
        {
            //Destroy(transform.root.gameObject);
        }
    }

    public void DmgFunct()
    {
        if (isDamaged == false) {
            newHp = newHp - damage;
            isDamaged = true;
        }
        StartCoroutine(IsDamaged());
    }

    IEnumerator IsDamaged()
    {
        isDamaged = true;
        yield return new WaitForSeconds(2f);
        isDamaged = false;


    }
}
