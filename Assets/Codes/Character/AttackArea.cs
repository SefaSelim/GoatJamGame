using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{

    public void OnTriggerEnter2D(Collider2D collider)
    {
        Debug.Log("iften Ã¶nce");
        if(collider.GetComponent<Health>()!=null)
        {
            Debug.Log("iften sonra");
            Health health = collider.GetComponent<Health>();
            health.Damage(10);

        }

    }
}