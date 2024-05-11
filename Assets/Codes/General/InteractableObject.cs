using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractableObject : CollidableObject
{   
    bool isInside = false;
    public Animator animator;
    private bool z_Interacted = true;

    float timer=0;

    protected override void OnCollided(GameObject collidedObject)
    {
        timer += Time.deltaTime;
       if(Input.GetKey(KeyCode.E))
       {
        OnInteract();
        isInside = true;

       } 
        if(isInside&&(Input.GetKey(KeyCode.A)||Input.GetKey(KeyCode.D)||Input.GetKey(KeyCode.W)||Input.GetKey(KeyCode.S)))
        {
            timer = 0;
            animator.SetBool("isCollecting",false);
            isInside = false;
            z_Interacted = true;
        }



        if(timer > 1.9&&isInside)
            {
                timer = 0;
                animator.SetBool("isCollecting",false);
                Destroy(gameObject);
                isInside = false;
            
            }

    }
    protected virtual void OnInteract()
    {
        if(z_Interacted)
        {
            z_Interacted = false;
            Debug.Log("Interact with" + name);
            animator.SetBool("isCollecting",true);
            timer = 0;

        }

    }
}
