using UnityEngine;

public class EnemyAttackArea : MonoBehaviour
{   
    public GameObject attackarea;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("iften Ã¶nce");
        if (collision.GetComponent<Health>() != null)
        {
            Debug.Log("iften sonra");
            Health health = collision.GetComponent<Health>();
            health.Damage(10);
        }

        if (collision.GetComponent<KnockbackFeedback>() != null)
        {
            KnockbackFeedback knockback = collision.GetComponent<KnockbackFeedback>();
            knockback.PlayFeedback(attackarea);
        }
    }
}
