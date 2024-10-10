using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WallJump : MonoBehaviour
{
    private Rigidbody2D rb;
	private float wallJumpingDirection;
    public bool isWallJumping;
    public float wallJumpingTime = 0.2f,wallJumpingCounter,wallJumpingDuration = 0.4f;
    public Vector2 wallJumpingPower = new Vector2(0f,2f);
    private bool isFacingRight = false;
    
    private Vector2 startTouchPosition, endTouchPosition;
    private PlayerMovementLeftandRight playerMovement;
    private WallJump01 wallJump01;
    private Jump_Button jump_Button; 

    public bool jumpAllowed = false;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D> ();   
        playerMovement = GetComponent<PlayerMovementLeftandRight>(); // Initialize playerMovement
        wallJump01 = GetComponent<WallJump01>(); // Initialize wallJump01
        jump_Button = GetComponent<Jump_Button>(); // Initialize swipeJump
    }

    // Update is called once per frame
    void Update()
    {
        if(playerMovement.direction == 1f)
		{
			isFacingRight = true;
		}
		else if(playerMovement.direction == -1f)
		{
			isFacingRight = false;
		} 
        SwipeCheck();
        wallJump();
    }
private void SwipeCheck()
	{
		//to know where the touch is begining from and ending
		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began)
			startTouchPosition = Input.GetTouch (0).position;

		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Ended)
		{
			//to know the distance between begining touch and ending touch along the y axis
			endTouchPosition = Input.GetTouch (0).position;
			if (endTouchPosition.y > startTouchPosition.y && rb.velocity.y == 0)
				jumpAllowed = true;
		}
	}	
    private void wallJump()
    {
        if(wallJump01.isWallsliding)
        {
            isWallJumping = false;
            wallJumpingDirection = -transform.localScale.x;
            wallJumpingCounter = wallJumpingTime;

            CancelInvoke(nameof(StopWallJumping));
        }
        else
        {
            wallJumpingCounter -= Time.deltaTime;
        }

        if(playerMovement.jumpAllowed && wallJumpingCounter > 0f)
        {
            isWallJumping = true;
            rb.velocity = new Vector2(wallJumpingDirection * wallJumpingPower.x , wallJumpingPower.y);
            wallJumpingCounter = 0f;
            Debug.Log("Gokul");

            if(transform.localScale.x != wallJumpingDirection)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= 1f;
                transform.localScale = localScale;   
            }
            Invoke(nameof(StopWallJumping), wallJumpingDuration);
        }

    }

    private void StopWallJumping()
    {
        isWallJumping = false;
    }

    

}
