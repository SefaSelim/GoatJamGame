using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    public ShipToRoom shipToRoom;
      private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            shipToRoom.keynumber += 1;
            Object.Destroy(gameObject);
            Debug.Log("Player trigger alanına girdi!");
            

        
        }
    }
}
