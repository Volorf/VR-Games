using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Vector3 pos;
    public float destinationYPointMin = 80f;
    public float destinationYPointMax = 120f;
    public float minSpeed = 2f;
    public float maxSpeed = 7f;
    public Transform target;
    public float speed;

    public bool readyToAttack = false;
    public float destinationYPoint;
    public Vector3 destinationPoint;
    
    void Start()
    {
        SetData();
    }

    public void SetData() 
    {
        destinationYPoint = Random.Range(destinationYPointMin, destinationYPointMax);
        EnemyData ed = transform.GetComponent<EnemyData>();
        pos.x = ed.pos.x;
        // pos.y = ed.pos.y;
        pos.y = destinationYPoint;
        pos.z = ed.pos.z;
        target = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
        speed = Random.Range(minSpeed, maxSpeed);
        // transform.LookAt(target);
        destinationPoint = new Vector3(transform.position.x, destinationYPoint, transform.position.z);
    }

    void Update()
    {
        if(readyToAttack)
        {
            Move();
        }
        else
        {
            MoveToDestinationYPoint();
        }
        
    }

    void MoveToDestinationYPoint()
    {
        float step =  speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, destinationPoint, step);
        if(Vector3.Distance(transform.position, destinationPoint) < 0.1f)
        {
            readyToAttack = true;
        }
    }

    
    public virtual void Move() 
    {
        // Ancestors will write its implementation
    }

}
