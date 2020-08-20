using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedMovement : EnemyMovement
{
    // void Update()
    // {
    //     Move();
    // }

    public override void Move() 
    {
        float step =  speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}
