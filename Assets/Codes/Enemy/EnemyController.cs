using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Animator enemyAnimator;
    private float Timer;
    private Rigidbody2D rb;
    public Transform homepos;
    private Transform target;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxrange;
    [SerializeField]
    private float minrange;
    [SerializeField]
    private float attackRange;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); 
        target = FindObjectOfType<CharacterMovement>().transform;
        Timer = 0;

    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Vector3.Distance(target.position, transform.position) <= maxrange && Vector3.Distance(target.position, transform.position) >= minrange)
        { followPlayer(); }
        else if (Vector3.Distance(target.position, transform.position) >= maxrange)
        {
             rb.velocity = Vector2.zero;
             GoHome();

             }
             if (Vector3.Distance(target.position, transform.position)<attackRange&&Timer>1)
             {
                    enemyAnimator.SetBool("Attacking",true);
                    //hittin here
                    Timer = 0;

             }
             else
             {
                enemyAnimator.SetBool("Attacking",false);
             }

//asagi yön
if(target.position.y-transform.position.y<0&&Mathf.Abs(target.position.y-transform.position.y)>Mathf.Abs(target.position.x-transform.position.x))
{
    enemyAnimator.SetBool("WalkingDown",true);
}
else
{
    enemyAnimator.SetBool("WalkingDown",false);
}

//yukarı yön
if(target.position.y-transform.position.y>0&&Mathf.Abs(target.position.y-transform.position.y)>Mathf.Abs(target.position.x-transform.position.x))
{
    enemyAnimator.SetBool("WalkingUp",true);
}
else
{
    enemyAnimator.SetBool("WalkingUp",false);
}


//sag yon
if(target.position.x-transform.position.x>0&&Mathf.Abs(target.position.x-transform.position.x)>Mathf.Abs(target.position.y-transform.position.y))
{
    enemyAnimator.SetBool("WalkingRight",true);
}
else
{
    enemyAnimator.SetBool("WalkingRight",false);
}


//sol yon
if(target.position.x-transform.position.x<0&&Mathf.Abs(target.position.x-transform.position.x)>Mathf.Abs(target.position.y-transform.position.y))
{
    enemyAnimator.SetBool("WalkingLeft",true);
}
else
{
    enemyAnimator.SetBool("WalkingLeft",false);
}




    }

    public void followPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
    public void GoHome()
    {
        transform.position = Vector3.MoveTowards(transform.position, homepos.position, speed * Time.deltaTime);

    }
}
