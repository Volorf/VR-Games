using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Needle : MonoBehaviour
{
    public bool triggered = false;
    public float speed = 10f;

    AudioSource audioSource;
    public AudioClip pew;
    [Range(0,1f)] public float pewVolume;
    float gravity;
    public float acc = 0.001f;
    bool wasShot = false;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        gravity = acc;
    }

    // Update is called once per frame
    void Update()
    {
        if(triggered) {
            GoNeedle();
            gravity += acc;
            speed -= acc * 10;
            if(!wasShot)
            {
                audioSource.PlayOneShot(pew, pewVolume);
                wasShot = true;
            }
        }
    }

    void GoNeedle() {
        transform.Translate(new Vector3(0, 0 - gravity, 1 * Time.deltaTime * speed));
        Destroy(this.gameObject, 5f);
    }

    void OnTriggerEnter(Collider other) {
        if (other.tag == "Enemy") {
            MeshRenderer meshRend = GetComponent<MeshRenderer>();
            meshRend.material.color = Color.red;
            meshRend.material.SetColor("_EmissionColor", Color.red);
            Destroy(this.gameObject, 1f);
        }
    }

    void OnTriggerExit() {
        // MeshRenderer meshRend = GetComponent<MeshRenderer>();
        // meshRend.material.color = Color.white;
        // meshRend.material.SetColor("_EmissionColor", Color.white);
        
    }

}
