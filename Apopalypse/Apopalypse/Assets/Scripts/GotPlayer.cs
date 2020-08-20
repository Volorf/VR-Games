using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GotPlayer : MonoBehaviour
{
    Transform target;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
    }
    void Update()
    {
        PlayerWasGot();
    }
    public void PlayerWasGot() 
    {
        if(transform.position.z < target.position.z) 
        {
            Destroy(this.gameObject);
        }
    }
}
