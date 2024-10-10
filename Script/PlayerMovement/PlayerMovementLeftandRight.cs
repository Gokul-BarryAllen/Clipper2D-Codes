using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementLeftandRight : MonoBehaviour
{
    private Rigidbody2D Player;
    public float moveSpeed = 70f;
    public float direction;
    public float a = 2.186005f, b = 2.186005f;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private Animator playerAnimation;
    public bool isGround,isEnemy = false;
    public bool jumpAllowed = false;

    public float jumpForce = 500f;

    AudioManager1 audioManager;
    
    NewControls controls;
    
    private void Awake()
    {
        controls = new NewControls();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager1>();
        controls.Enable();

        controls.Player.Move.performed += info =>
        {
            direction = info.ReadValue<float>();
        };
    }
    
    
    
    void Start()
    {
        Player = GetComponent<Rigidbody2D>();
        playerAnimation = GetComponent<Animator>();
    }

    void Update()
    {
        Player.velocity = new Vector2 (direction*moveSpeed*Time.deltaTime,Player.velocity.y);

        isGround = Physics2D.OverlapCircle(groundCheck.position,0.2f,groundLayer);
        playerAnimation.SetFloat("Speed",Mathf.Abs(Player.velocity.x));
        playerAnimation.SetBool("OnGround",isGround);
        playerAnimation.SetBool("IsEnemy",isEnemy);   

        
        
    }
    
    public void LeftInput()
    {
        audioManager.PlaySFX(audioManager.Run);
        direction = -1;
        transform.localScale = new Vector2(-a,b);
        
    }

    public void RightInput()
    {
        direction = 1;
        transform.localScale = new Vector2(a,b);
        audioManager.PlaySFX(audioManager.Run);
    }
    public void ButtonUp()
    {
        direction = 0;
        jumpAllowed = false;
    }
    public void JumpInput()
    {
        if (isGround) {
            
			Player.AddForce (Vector2.up * jumpForce);
            audioManager.PlaySFX(audioManager.Jump);
			
		}
        jumpAllowed = true;
    }
    
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Obstacles"))
        {
             isEnemy = true;
             audioManager.PlaySFX(audioManager.Hurt);
        }

        if (collision.CompareTag("Gem"))
        {
             audioManager.PlaySFX(audioManager.Gem);
        }

        if (collision.CompareTag("Coin"))
        {
             audioManager.PlaySFX(audioManager.Coin);
        }
        if (collision.CompareTag("Key") || collision.CompareTag("Artefact"))
        {
            audioManager.PlaySFX(audioManager.KeyandArtefact);
        }
        if (collision.CompareTag("GameComp"))
        {
             audioManager.PlaySFX(audioManager.GameCompletion);
        }
         if (collision.CompareTag("SkillEnabler"))
        {
             audioManager.PlaySFX(audioManager.SkillEnabler);
        }
         if (collision.CompareTag("Treasure"))
        {
             audioManager.PlaySFX(audioManager.Treasure);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy") || collision.CompareTag("Obstacles"))
        {
             isEnemy = false;
        }
    }
}
