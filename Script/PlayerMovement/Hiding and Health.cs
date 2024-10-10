using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AdaptivePerformance.VisualScripting;

public class HidingandHealth : MonoBehaviour
{
    
    
    private bool canHide = false;
    private bool hiding = false;

    AudioManager1 audioManager;
    private SpriteRenderer rend;

    public Image fillBar;
    public float health;
    public Text lifecount;
    public GameOverScreen gameOverScreen;
    private Animator playerAnimation;
    public bool isDead = false;
    Vector2 checkpointPos;
    public GameObject FallDector;
    
    public Text CoinText;
    public Text GemText;
    public Text TreasureText;
    public Text CrystalText;
    public Text ArtefactText;
     

    
    
    
    
    void Start()
    {
        
        rend = GetComponent<SpriteRenderer>();
        playerAnimation = GetComponent<Animator>();
        
        checkpointPos = transform.position;
        lifecount.text = "x " + Scoring.liveRemaining;
        CoinText.text = "x " + Scoring.TotalCoin;
        GemText.text = "x " + Scoring.TotalGem;
        TreasureText.text = "x " + Scoring.Treasure;
        ArtefactText.text = "x " + Scoring.Artefact;
        CrystalText.text = "x " + Scoring.Crystal;

    }
    void Update()
    {
        if (canHide)
        {
            
            hiding = true;
            Physics2D.IgnoreLayerCollision(7,8,true);
            rend.sortingOrder = 2;
            Debug.Log("Hiding");

        }
        else
        {
            Physics2D.IgnoreLayerCollision(7,8,false);
            rend.sortingOrder = 0;
            hiding = false;

        }
        fillBar.fillAmount = health/100;
        playerAnimation.SetBool("Death",isDead); 
    }

   void FixedUpdate()
   {
      

   }
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HidingSpot"))
        {
            canHide = true;
        }
        if (collision.gameObject.CompareTag("Coin"))
        {
            Scoring.TotalCoin +=1;
            CoinText.text = "x" + Scoring.TotalCoin;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Gem"))
        {
            Scoring.TotalGem +=1;
            GemText.text = "x" + Scoring.TotalGem;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Treasure"))
        {
            Scoring.Treasure +=1;
             TreasureText.text = "x " + Scoring.Treasure;
            Destroy(collision.gameObject);
        }
        if(collision.tag == "Key")
        {
        
           Scoring.Crystal +=1;
            CrystalText.text = "x" + Scoring.Crystal;
           
        }
        
        if(collision.tag == "Artefact")
        {
        
            Scoring.Artefact +=1;
            ArtefactText.text = "x" + Scoring.Artefact;
            
        }
        


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("HidingSpot"))
        {
            canHide = false;
        }
    }


    public void LoseHealth(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            if(Scoring.liveRemaining > 1)
            {
                Scoring.liveRemaining--;
                lifecount.text = "x " + Scoring.liveRemaining;
                ReSpawn();
            }
            else
            {
                isDead = true;

                 lifecount.text = "x 0";


                Invoke("GamOver",4);
            }
            
        }

    }

    public void ReSpawn()
    {
        health = 100;
        transform.position = checkpointPos;
    }


    public void AddHealth(float AddHelth)
    {
         if (health < 100)
        {
        health += AddHelth;
        health = Mathf.Min(health, 100);
        
        }
    }

    private void GamOver()
    {
        gameOverScreen.Setup();
    }

}