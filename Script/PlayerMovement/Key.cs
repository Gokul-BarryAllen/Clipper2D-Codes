using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoBehaviour
{

    public int keysCollected = 0;
    public int totalKeys = 2;
    public GameObject dooron;
   
    
    


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Key")
        {
        
            keysCollected++;
            Destroy(collision.gameObject);
            CheckKeys();
        }
    }


    void CheckKeys()
    {
        if (keysCollected == totalKeys)
        {
            OpenDoor();
        }
    }

    void OpenDoor()
    {
        dooron.GetComponent<PolygonCollider2D>().enabled = false;
    }
}
