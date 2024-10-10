using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashButton : MonoBehaviour
{
   private Rigidbody2D Player;
    public float dashForce = 400f,dashDist = 0.8f;
    private float a = 0.28f, b = 0.28f;
   
    [SerializeField]private CoolDown cooldown;

    void Start()
    {
        Player = GetComponent<Rigidbody2D>();
       
    }

    public void PointerDownLeft()
    {
        if( cooldown.isCoolingDown) return;

        else 
        {
            Player.velocity = new Vector2(dashForce*dashDist*1,Player.velocity.y);
            transform.localScale = new Vector2(-a,b);
            cooldown.StartCooldown();
        }
    }
   
        public void PointerDownRight()
    {
        if( cooldown.isCoolingDown) return;

        else 
        {
            Player.velocity = new Vector2(dashForce*dashDist,Player.velocity.y);
            transform.localScale = new Vector2(a,b);
            cooldown.StartCooldown();
        }
    }

   

    
}