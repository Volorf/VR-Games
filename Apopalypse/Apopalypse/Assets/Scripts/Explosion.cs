using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public Color color;
    ParticleSystemRenderer psr;

    void Awake()
    {
        psr = transform.GetComponent<ParticleSystemRenderer>();
    }
    void Start()
    {
        psr.material.color = color;
        Destroy(this.gameObject, 1f);
    }
}
