using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{

    public Animator animator;



    public float moveSpeed = 5f; // Hareket hızı
    bool isMoving = false;

    void setDefault()
    {
            animator.SetBool("isMovingDown",false);
            animator.SetBool("isMovingUp",false);
            animator.SetBool("isMovingLeft",false);
            animator.SetBool("isMovingRight",false);
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.S)||Input.GetKey(KeyCode.D))
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        
        animator.SetBool("isMoving",isMoving);
        animator.SetFloat("moveSpeed",moveSpeed);

        if (Input.GetKey(KeyCode.W))
        {
            setDefault();
            animator.SetBool("isMovingUp",true);

            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }


        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
            setDefault();
            animator.SetBool("isMovingLeft",true);
        }


        if (Input.GetKey(KeyCode.S))
        {
            setDefault();
            animator.SetBool("isMovingDown",true);

            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }


        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
            setDefault();
            animator.SetBool("isMovingRight",true);
        }
    }

}
