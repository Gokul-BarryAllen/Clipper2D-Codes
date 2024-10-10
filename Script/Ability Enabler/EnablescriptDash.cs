using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablescriptDash : MonoBehaviour
{
    public Behaviour Dash;

    void Start()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
   {
    if(collision.tag == "Player")
    {
        
        FindAnyObjectByType<Dash>().enabled = true;
        Destroy(gameObject);
    }
   }
    
}
