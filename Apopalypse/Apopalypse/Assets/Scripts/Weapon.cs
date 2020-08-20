using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject needle;

    public float fireSpeed = 0.5f;

    float timer;
    public bool autoFire = false;

    void Start()
    {
        timer = fireSpeed;
        CreateNeedle();
    }

    void CreateNeedle() {
        GameObject createdNeedle = Instantiate(needle, transform.position, transform.rotation);
        createdNeedle.transform.parent = this.gameObject.transform;
    }

    // Update is called once per frame  
    void Update()
    {
      if(timer >= fireSpeed && autoFire) {
          Fire();
          CreateNeedle();
          timer = 0f;
      }   
      timer += Time.deltaTime;

    }

    void Fire() {
        Needle currentNeedle = GetComponentInChildren<Needle>();
        currentNeedle.GetComponent<Needle>().triggered = true;
        currentNeedle.transform.parent = null;
    }

    public void AutoFire (float _fl) {
        if(_fl > 0.75) {
            autoFire = true;
        } 
        else {
            autoFire = false;
        }
    }

}
