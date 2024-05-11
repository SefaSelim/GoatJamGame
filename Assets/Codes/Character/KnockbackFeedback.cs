using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KnockbackFeedback : MonoBehaviour
{
   [SerializeField]
   private Rigidbody2D rb2d;

   public void PlayFeedback(GameObject sender)
   {
        StopAllCoroutines();
        Onbegin?.Invoke();
        Vector2 direction = (transform.position-sender.transform.position).normalized;
        rb2d.AddForce(direction*strength,ForceMode2D.Impulse);
        StartCoroutine(Reset());
   }

   [SerializeField]
    private float strength = 16, delay = 0.15f;
    public UnityEvent Onbegin,Ondone;
    private IEnumerator Reset()
    {
        yield return new WaitForSeconds(delay);
        rb2d.velocity = Vector3.zero;
        Ondone?.Invoke();
    }
}