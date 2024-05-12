using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public int enemyhealth = 100;
    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative damage");

        }
        this.enemyhealth -= amount;

        if (enemyhealth <= 0)
        {
            EnemyDie();
        }
    }
    private void EnemyDie()
    {
        Debug.Log("You are dead.");
        Destroy(gameObject);
    }
}