using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    public float changetime;
    public string scenename;
    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        changetime-= Time.deltaTime;
        if(changetime < 0)
        {
             SceneManager.LoadScene(scenename);
        }
       
    }
}
