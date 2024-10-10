using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Consumables : MonoBehaviour
{
   public int ReturnAmount = 20;
   AudioManager1 audioManager;


   private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager1>();
    }
        

   private void Reset()
   {
    GetComponent<BoxCollider2D>().isTrigger = true; 
   }

   private void OnTriggerEnter2D(Collider2D collision)
   {
    if(collision.tag == "Player")
    {
        
        FindAnyObjectByType<HidingandHealth>().AddHealth(ReturnAmount);
        Destroy(gameObject);
        audioManager.PlaySFX(audioManager.Cherry);
    }
   }
}
