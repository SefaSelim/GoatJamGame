using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : CollidableObject
{   
    public Animator animator;
    private bool z_Interacted = false;

    float timer=0;

    protected override void OnCollided(GameObject collidedObject)
    {
        timer += Time.deltaTime;
       if(Input.GetKey(KeyCode.E))
       {
        OnInteract();

       }       
        if(timer > 1)
            {
                timer = 0;
                animator.SetBool("isCollecting",false);
                Destroy(gameObject);
            
            }

    }
    protected virtual void OnInteract()
    {
        if(z_Interacted == false)
        {
            z_Interacted = true;
            Debug.Log("Interact with" + name);
            animator.SetBool("isCollecting",true);
            timer = 0;

        }

    }
}
