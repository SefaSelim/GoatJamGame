using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ShipToRoom : MonoBehaviour
{
    public int keynumber = 0;
        private void OnTriggerEnter2D(Collider2D other)
    {
        
        // Çarpışmanın olduğu nesnenin etiketini kontrol et
        if (other.CompareTag("Player"))
        {
            if(keynumber == 3)
            {
            Debug.Log("cutscene collided");
            SceneManager.LoadScene("Real_Shiproom");}
           
        }
    }

}
