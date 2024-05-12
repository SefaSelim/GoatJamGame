using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{
    [SerializeField] public int health;
    [SerializeField] public script playerscript;

    public AudioSource audioSource;

    public AudioClip deathsound;
    public AudioClip damageSound;
    public UIManager uiManager;
    public GameObject deathwindow;
    private int MAX_HEALTH = 100;


    void Start()
    {
        
        if(playerscript.isstart == false)
        {
            playerscript.playerHealth = 100;
            playerscript.isstart = true;
        }
        health = playerscript.playerHealth;

    }

    // Update is called once per frame
    void Update()
    {
        // UI'da canı göstermek için UIManager'a erişim sağla
        uiManager.UpdateHealthUI(health);
    }


    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative damage");

        }
        this.health -=amount;
        playerscript.playerHealth = health;
        audioSource.PlayOneShot(damageSound);

        if (health<= 0)
        {
            
            Die();
        }
    }
    public void Heal(int amount)
    {
         if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative healing");

        }
        if(health + amount > MAX_HEALTH)
        {
            this.health = MAX_HEALTH;
        }
        else{
            this.health+=amount;
        }




    }
    

    private void Die()
    {
        playerscript.isstart = false;
        Debug.Log("You are dead.");
        // Destroy(gameObject);
        if (gameObject.CompareTag("Player"))
        {
            Debug.Log("öldü");
            audioSource.PlayOneShot(deathsound);
            deathwindow.SetActive(true);
            uiManager.UpdateHealthUI(health);
            Time.timeScale = 0f;
            
        }
    }
}