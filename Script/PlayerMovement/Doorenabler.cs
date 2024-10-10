using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Doorenabler : MonoBehaviour
{
    public int artefactCollected = 0;
    public int totalartefacts = 2;
    public GameObject door;
   
    

    // Update is called once per frame
    
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Artefact")
        {
        
            artefactCollected ++;
            Destroy(collision.gameObject);
            CheckKeys();
        }
    }


    void CheckKeys()
    {
        if (artefactCollected == totalartefacts)
        {
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        door.SetActive(true);
    }
}
