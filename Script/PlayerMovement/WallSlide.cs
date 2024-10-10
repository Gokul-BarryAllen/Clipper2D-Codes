using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump01 : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool isWallsliding = false;
    public float wallSlidingSpeed = 0.8f;
    [SerializeField] private Transform wallCheck;
    [SerializeField] private LayerMask wallLayer;
    

    
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        WallSlide();
    }

    private void WallSlide()
    {
        if(isWalled() )
        {//checking if player is wallsliding
            isWallsliding = true;
            rb.velocity = new Vector2(rb.velocity.x, Mathf.Clamp(rb.velocity.y, -wallSlidingSpeed, float.MaxValue));
        }
        else 
        {
            isWallsliding = false;
        }
    }

     private bool isWalled()
    {//checking if player is touching the wall
        return Physics2D.OverlapCircle(wallCheck.position,0.2f,wallLayer);
    }

   



   

}
