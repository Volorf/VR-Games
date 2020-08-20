using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityDart : MonoBehaviour
{
    
    float speed = 10f;
    float acc = 0.001f;
    float gravity = 0f;


    void Start()
    {
        
    }

    void Update()
    {   
        
        transform.Translate(new Vector3(0, 0 - gravity, 1 * Time.deltaTime * speed));
        speed -= acc * 10;

        gravity += acc;
    }
}
