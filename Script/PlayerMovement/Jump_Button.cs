using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump_Button : MonoBehaviour
{
    // Start is called before the first frame update
   private Vector2 startTouchPosition, endTouchPosition;
	private Rigidbody2D rb;
	public float jumpForce = 500f,x = 0.28f,y =0.28f;
    public bool jumpAllowed = false;
    
	

	[SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
	private PlayerMovementLeftandRight playerMovement;
  	
	private void Start ()
	{
		rb = GetComponent<Rigidbody2D> ();
	}
	
	
	private void Update ()
	{
		
         if (!isGrounded() && rb.velocity.y == 0)
				jumpAllowed = true; 
        
	}
			

	
	
	
	public bool isGrounded()
    {//checking if player is grounded
        return Physics2D.OverlapCircle(groundCheck.position,0.2f,groundLayer);
        
    }

    public void JumpInput()
    {
        if (isGrounded() ) 
		{
			rb.AddForce (Vector2.up * jumpForce);
			jumpAllowed = false;
		}
    }
    
}
