using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class eva : MonoBehaviour
{
    public AttackArea attackArea;
    public InteractableObject interactableObject;
    public Dialogue dialogue;
    
    bool flag = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(attackArea.playerDamage == 20)
        {
            SceneManager.LoadScene("FINALALIEN");

        }
        
        if( interactableObject.isInside == true )
        {
            dialogue.SetActivetrue();
            if(flag == false){
            dialogue.StartDialogue();
            flag = true;}
        }
    }
}
