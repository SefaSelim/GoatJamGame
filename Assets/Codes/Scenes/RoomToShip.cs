using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RoomToShip : MonoBehaviour
{
     private void OnTriggerEnter2D(Collider2D other)
    {
        // Çarpışmanın olduğu nesnenin etiketini kontrol et
        if (other.CompareTag("Player"))
        {
    
            Debug.Log("cutscene collided");
            SceneManager.LoadScene("Ship");
           
        }
    }
}


