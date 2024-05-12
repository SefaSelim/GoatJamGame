using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class sahne : MonoBehaviour
{
     [SerializeField] 
    private script playerhealth;
    // Start is called before the first frame update
    void Start()
    {
        playerhealth.playerHealth = 100;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
