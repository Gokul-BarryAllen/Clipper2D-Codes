using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[RequireComponent(typeof(BoxCollider2D))]
public class LevelCompletion : MonoBehaviour
{
    public GameObject GameCompletion;
    
    
    
   
   private void Reset()
   {
    GetComponent<BoxCollider2D>().isTrigger = true; 
   }

   private void OnTriggerEnter2D(Collider2D collision)
   {
    if(collision.tag == "Player")
    {
        
            GameCompletion.SetActive(true);
            GameObject.FindAnyObjectByType<Key>().keysCollected = 0;
            GameObject.FindAnyObjectByType<Doorenabler>().artefactCollected = 0;
            Scoring.Artefact = 0;
            Scoring.Crystal = 0;
        
    }
   }

   
}

