using UnityEngine;
using UnityEngine.SceneManagement;
  
public class Singletonalien : MonoBehaviour
{
    private static Singletonalien obje = null;
     
    void Awake()
    {
        if( obje == null )
        {
            obje = this;
            DontDestroyOnLoad( this );
             
            SceneManager.sceneLoaded += SahneYuklendi;
        }
        else if( this != obje )
        {
            Destroy( gameObject );
        }
    }
     
    void OnDestroy()
    {
        SceneManager.sceneLoaded -= SahneYuklendi;
    }
     
    // Yeni bir sahne yüklenince çağrılır
    void SahneYuklendi( Scene scene, LoadSceneMode mode )
    {
        if( scene.name == "MainMenu" )
        {
            obje = null;
            Destroy( gameObject );
        }
    }
}