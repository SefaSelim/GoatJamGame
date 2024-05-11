using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public bool attacking = false;
    public GameObject attackarea;
    private Collider2D attackAreacollider;
    private Transform areaTransform;
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

    private float timetoAttack = 0.25f;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        attackAreacollider = transform.GetChild(0).GetComponent<Collider2D>();
        areaTransform = transform.GetChild(0);
        rb = GetComponent<Rigidbody2D>();
        target = FindObjectOfType<CharacterMovement>().transform;
        Timer = 0;

    }

    // Update is called once per frame
    void Update()
    {
        if (attacking)
        {
            timer += Time.deltaTime;
            if (timer >= timetoAttack)
            {
                timer = 0;
                attacking = false;
                 attackAreacollider.enabled = false;
                
            }

        }
        Timer += Time.deltaTime;
        if (Vector3.Distance(target.position, transform.position) <= maxrange && Vector3.Distance(target.position, transform.position) >= minrange)
        { followPlayer(); }
        else if (Vector3.Distance(target.position, transform.position) >= maxrange)
        {
            rb.velocity = Vector2.zero;
            GoHome();

        }
        if (Vector3.Distance(target.position, transform.position) < attackRange && Timer > 1)
        {
            enemyAnimator.SetBool("Attacking", true);
            Attack();
            Timer = 0;

        }
        else
        {
         
            enemyAnimator.SetBool("Attacking", false);
        }

        //asagi yön
        if (target.position.y - transform.position.y < 0 && Mathf.Abs(target.position.y - transform.position.y) > Mathf.Abs(target.position.x - transform.position.x))
        {
            areaTransform.rotation = Quaternion.Euler(0f, 0f, 270f);
            areaTransform.position = new Vector3(transform.position.x - 0.3f, transform.position.y - 2.2f, areaTransform.position.z);
            enemyAnimator.SetBool("WalkingDown", true);

        }
        else
        {
            enemyAnimator.SetBool("WalkingDown", false);
        }

        //yukarı yön
        if (target.position.y - transform.position.y > 0 && Mathf.Abs(target.position.y - transform.position.y) > Mathf.Abs(target.position.x - transform.position.x))
        {
            areaTransform.rotation = Quaternion.Euler(0f, 0f, 90f);
            areaTransform.position = new Vector3(transform.position.x + 0.4f, transform.position.y + 2.2f, areaTransform.position.z);
            enemyAnimator.SetBool("WalkingUp", true);
        }
        else
        {
            enemyAnimator.SetBool("WalkingUp", false);
        }


        //sag yon
        if (target.position.x - transform.position.x > 0 && Mathf.Abs(target.position.x - transform.position.x) > Mathf.Abs(target.position.y - transform.position.y))
        {
            areaTransform.rotation = Quaternion.Euler(0f, 0f, 360f);
            areaTransform.position = new Vector3(transform.position.x + 1.4f, transform.position.y - 0.2f, areaTransform.position.z);
            enemyAnimator.SetBool("WalkingRight", true);
        }
        else
        {
            enemyAnimator.SetBool("WalkingRight", false);
        }


        //sol yon
        if (target.position.x - transform.position.x < 0 && Mathf.Abs(target.position.x - transform.position.x) > Mathf.Abs(target.position.y - transform.position.y))
        {
            areaTransform.rotation = Quaternion.Euler(0f, 0f, 180f);
            areaTransform.position = new Vector3(transform.position.x - 1.4f, transform.position.y + 0.3f, areaTransform.position.z);
            enemyAnimator.SetBool("WalkingLeft", true);
        }
        else
        {
            enemyAnimator.SetBool("WalkingLeft", false);
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
    private void Attack()
    {
        attackAreacollider.enabled = true;
        attacking = true;

    }
}
