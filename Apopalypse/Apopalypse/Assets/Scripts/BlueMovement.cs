using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueMovement : EnemyMovement
{
    public float reposeDurMin = 0.5f;
    public float reposeDurMax = 2f;
    float reposeDur;

    public float xRange = 5f;
    public float yRange = 5f;
    public float zRange = 5f;
    float reposeTimer = 0f;
    bool generateRandomPos = true;

    float xOffset;
    float yOffset;
    float zOffset;
    Vector3 newPos;

    int count = 0;
    void Start()
    {
        base.SetData();
        reposeDur = Random.Range( reposeDurMin, reposeDurMax );
    }

    // Update is called once per frame

    public override void Move()
    {
        float step =  speed * Time.deltaTime;
        
        if (reposeTimer >= reposeDur)
        {
            reposeTimer = 0;
            generateRandomPos = true;
        }
        else if (reposeTimer >= reposeDur/2)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
        else if (reposeTimer <= reposeDur / 2)
        {
            // Debug.Log(count++);
            // float randomAngleUp = Random.Range(-angleRange, angleRange);
            // float randomAngleRight = Random.Range(-angleRange, angleRange);
            // transform.RotateAround(target.position, Vector3.up, randomAngleUp);
            // transform.RotateAround(target.position, Vector3.right, randomAngleRight);
            // transform.LookAt(target);
            if(generateRandomPos)
            {

                float dist = Vector3.Distance(transform.position, target.position);

                generateRandomPos = false;
                xOffset = Random.Range( -xRange, xRange );
                yOffset = Random.Range( -yRange, yRange );
                zOffset = Random.Range( 0f, zRange );

                float calcXOffset = dist.Remap(0f, pos.z, 0f, xOffset);
                float calcYOffset = dist.Remap(0f, pos.z, 0f, yOffset);
                float calcZOffset = dist.Remap(0f, pos.z, 0f, zOffset);

                newPos = new Vector3(
                    transform.position.x + calcXOffset, 
                    transform.position.y + calcYOffset, 
                    transform.position.z - calcZOffset);
            }

            transform.position = Vector3.MoveTowards(transform.position, newPos, step);
        } 

        reposeTimer += Time.deltaTime;
    }
}
