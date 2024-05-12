using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Health : MonoBehaviour
{
    [SerializeField] public int health = 100;

    public UIManager uiManager;
    public GameObject deathwindow;
    private int MAX_HEALTH = 100;


    void Start()
    {

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
        Debug.Log("You are dead.");
        Destroy(gameObject);
        if (gameObject.CompareTag("Player"))
        {
            deathwindow.SetActive(true);
            uiManager.UpdateHealthUI(health);
            Time.timeScale = 0f;
            
        }
    }
}