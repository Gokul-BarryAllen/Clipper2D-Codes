using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
 [RequireComponent(typeof(BoxCollider2D))]
public class PlatformMovement : MonoBehaviour
{
   
    //Reference to waypaoints
    public List<Transform> points;
    //Tyhe int value for the next point index
    public int nextID=0;
    //The value of that applies to ID for changing
    private int idChangeValue;
    //Speed of movement or Flying
    public float speed = 2f;
    
    public float x,y; 


    private void Reset()
    {
     Init();  
    }

    void Init()
    {
           
        //Create root object 
        GameObject root = new GameObject(name + "_Root");
        //Reset Position of Root to enemy
        root.transform.position = transform.position;
        //Set enemy object as child of root
        transform.SetParent(root.transform);
        //create waypoint object
        GameObject waypoints = new GameObject("Waypoints");
        //Reset waypoints position to root
        waypoints.transform.SetParent(root.transform);
        waypoints.transform.position = root.transform.position;
        //Make waypoint object child of root
        GameObject p1 = new GameObject("Point1");p1.transform.SetParent(waypoints.transform);p1.transform.position = root.transform.position;
        GameObject p2 = new GameObject("Point2");p2.transform.SetParent(waypoints.transform);p2.transform.position = root.transform.position;
        GameObject p3 = new GameObject("Point3");p3.transform.SetParent(waypoints.transform);p3.transform.position = root.transform.position;
        GameObject p4 = new GameObject("Point4");p4.transform.SetParent(waypoints.transform);p4.transform.position = root.transform.position;
        //create two waypoints and reset their position to waypoinyy objects
        //make the points children of waypoint object


        //Init points list then add the points to it

        points = new List<Transform>();
        points.Add(p1.transform);
        points.Add(p2.transform);
        points.Add(p3.transform);
        points.Add(p4.transform);

    }

    private void Update()
    {
        MoveToNextPoint();
    }

    void MoveToNextPoint()
    {
        //get to next point transform
        Transform goalPoint = points[nextID]; 
        //flip the enemy trandform to look into the point's direction
        if(goalPoint.transform.position.x > transform.position.x)
        {
            transform.localScale = new Vector3(x,y,1);
        }
        else
        {
            transform.localScale = new Vector3(-x,y,1);
        }
        //move the enemy towards the goal point
        transform.position = Vector2.MoveTowards(transform.position,goalPoint.position,speed*Time.deltaTime);
        //check distance between enemy and goal point to trigger next point
        if(Vector2.Distance(transform.position,goalPoint.position)<0.5f)
        {
            //Check if we are at the end of the line(make the change -1)
            if(nextID == points.Count - 1)
            {
                idChangeValue = -1;
            }
            if(nextID == 0)
            {
                idChangeValue = 1;
            }
            //2Points (0,1) next == points.count(2)-1
            //Check if we are at the start of the line(make the change 1)
            //Apply the change on the nextID
            nextID+= idChangeValue;
            //nextID
        }
    }
}

