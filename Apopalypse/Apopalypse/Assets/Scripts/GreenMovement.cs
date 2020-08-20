using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenMovement : EnemyMovement
{
    bool clockwise;
    public float freqMin = 0.5f;
    public float freqMax = 1f;

    public float attackDist = 5f;
    float freq;

    public float ampMin = 1f;
    public float ampMax = 3f;
    float amp;

    float calcAmp;

    void Start()
    {
        base.SetData();
        freq = Random.Range(freqMin, freqMax);
        amp = Random.Range(ampMin, ampMax);
        clockwise = Random.Range(0f, 1f) > 0.5 ? true : false;
    }

    public override void Move() 
    {
        float step =  speed * Time.deltaTime;

        if(Mathf.Abs(transform.position.z - target.position.z) >= attackDist)
        {
        float dist = Vector3.Distance(transform.position, target.position);
        calcAmp = dist.Remap(0f, pos.z, 0f, amp);
        // Debug.Log(pos.z);
        
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        Vector3 newPos = new Vector3(pos.x + (clockwise ? SinExpr() : CosExpr()), pos.y + (clockwise ? CosExpr() : SinExpr()), transform.position.z);
        transform.position = newPos;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        }
        
 
        
    }
    float CosExpr()
    {
        return Mathf.Cos(Time.time * freq) * calcAmp;
    }

    float SinExpr()
    {
        return Mathf.Sin(Time.time * freq) * calcAmp;
    }

}
