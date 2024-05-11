using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject attackArea = default;
    private Collider2D attackAreacollider;
    private bool attacking = false;

    private float timetoAttack = 0.25f;
    private float timer = 0;
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
        attackAreacollider = transform.GetChild(0).GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
        
    if(attacking)
    {
        timer+= Time.deltaTime;
        if(timer >= timetoAttack)
        {
            timer = 0;
            attacking = false;
            attackAreacollider.enabled = false;
        }

    }
    }


    private void Attack()
    {
        attacking = true;
        attackAreacollider.enabled = true;
        


    }
}