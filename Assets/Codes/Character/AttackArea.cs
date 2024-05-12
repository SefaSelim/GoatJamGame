using UnityEngine;

public class AttackArea : MonoBehaviour
{   
    public GameObject attackarea;
    private Transform playerTransform;
    public float donmeHizi = 100f;
    void Start()
    {
         playerTransform = transform.parent;

    }

    void Update()
    {
        Vector3 playerPosition = playerTransform.position;
        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 90f);
            transform.position = new Vector3(playerPosition.x+0.4f, playerPosition.y + 2.2f, transform.position.z);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 270f);
            transform.position = new Vector3(playerPosition.x-0.3f, playerPosition.y - 2.2f, transform.position.z);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 180f);
            transform.position = new Vector3(playerPosition.x - 1.4f, playerPosition.y+0.3f, transform.position.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 360f);
            transform.position = new Vector3(playerPosition.x +1.4f, playerPosition.y-0.2f, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("iften Ã¶nce");
        if (collision.GetComponent<EnemyHealth>() != null)
        {
            Debug.Log("iften sonra");
            EnemyHealth health = collision.GetComponent<EnemyHealth>();
            health.Damage(10);
        }

        if (collision.GetComponent<KnockbackFeedback>() != null)
        {
            KnockbackFeedback knockback = collision.GetComponent<KnockbackFeedback>();
            knockback.PlayFeedback(attackarea);
        }
    }
}
