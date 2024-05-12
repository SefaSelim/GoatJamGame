using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NewBehaviourScript : MonoBehaviour
{
      private void OnTriggerEnter2D(Collider2D other)
    {
        // Tetiklenen nesnenin etiketini kontrol et
        if (other.CompareTag("Player"))
        {
            // Sadece "Player" etiketine sahip nesnelerle trigger alanına girildiğinde bu blok çalışır
             SceneManager.LoadScene("Final");
            
            // Buraya istediğiniz işlemleri ekleyebilirsiniz.
        }
}}
