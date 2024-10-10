using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keycount : MonoBehaviour
{
    public GameObject panel;
    public Key key;
    
    private void Reset()
   {
    GetComponent<BoxCollider2D>().isTrigger = true; 
   }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
   {
    if(collision.tag == "Player")
    {
        if(key.keysCollected != 2)
            panel.SetActive(true);
     
        
    }
   }

    private void OnTriggerExit2D(Collider2D collision)
   {
    if(collision.tag == "Player")
    {
        
            panel.SetActive(false);
    }
   }

}
