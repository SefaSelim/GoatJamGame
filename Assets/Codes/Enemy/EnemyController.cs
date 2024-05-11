using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform homepos;
    private Transform target;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float maxrange;
    [SerializeField]
    private float minrange;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<CharacterMovement>().transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= maxrange && Vector3.Distance(target.position, transform.position) >= minrange)
        { followPlayer(); }
        else if (Vector3.Distance(target.position, transform.position) >= maxrange)
        { GoHome(); }
    }

    public void followPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
    public void GoHome()
    {
        transform.position = Vector3.MoveTowards(transform.position, homepos.position, speed * Time.deltaTime);

    }
}
