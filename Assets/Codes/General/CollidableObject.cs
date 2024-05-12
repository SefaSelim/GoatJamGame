using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class CollidableObject : MonoBehaviour
{
    public AttackArea attackArea;
    public Health health;
    private Collider2D z_collider;
    [SerializeField]
    private ContactFilter2D z_filter;
    private List<Collider2D> z_CollidedObjects = new List<Collider2D>(1);

    protected virtual void Start()
    {
        z_collider = GetComponent<Collider2D>();

    }
    protected virtual void Update()
    {
        z_collider.OverlapCollider(z_filter, z_CollidedObjects);
        foreach (var o in z_CollidedObjects)
        {
           
            OnCollided(o.gameObject);
        }

    }

    protected virtual void OnCollided(GameObject collidedObject)
    {
        Debug.Log("Collided with" + collidedObject.name);


    }
}
