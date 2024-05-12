using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinSound : MonoBehaviour
{
    public ShipToRoom shipToRoom;
    public AudioClip coinSounds;
    public AudioSource audioSource;
    int target;
    bool isActive = false;
    // Start is called before the first frame update
    void Start()
    {
        target = 0;
    }

    // Update is called once per frame
    void Update()
    {   
        if(shipToRoom.keynumber>target)
        {
            isActive = true;
            target++;
        }
        if (isActive)
        {
            audioSource.PlayOneShot(coinSounds);
            isActive = false;
        }
    }
}
