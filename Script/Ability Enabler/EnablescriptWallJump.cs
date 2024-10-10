using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablescriptWallJump : MonoBehaviour
{
    

    void Start()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
   {
    if(collision.tag == "Player")
    {
        
        FindAnyObjectByType<WallJump>().enabled = true;
        Destroy(gameObject);
    }
   }
    
}
