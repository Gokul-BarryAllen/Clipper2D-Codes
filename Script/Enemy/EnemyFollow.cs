using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float speed;
    public float lineofsite;
    private Transform player;

    
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position,transform.position);
        if(distanceFromPlayer<lineofsite)
        {
            transform.position = Vector2.MoveTowards(this.transform.position,player.position,speed*Time.deltaTime);
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lineofsite);
    }
}
