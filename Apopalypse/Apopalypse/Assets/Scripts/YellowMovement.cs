using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowMovement : EnemyMovement
{
    public float offsetMin = 0.1f;
    public float offsetMax = 0.5f;
    float offset;
    public float freqMin = 0.5f;
    public float freqMax = 2f;
    float freq;
    float noiseOffset;

    // Start is called before the first frame update
    void Start()
    {
        base.SetData();
        offset = Random.Range(offsetMin, offsetMax);
        freq = Random.Range(freqMin, freqMax);
        noiseOffset = Random.Range(10000, 20000);
    }

    // Update is called once per frame

    public override void Move()
    {
        float dist = Vector3.Distance(transform.position, target.position);
        float calcOffset = dist.Remap(0f, pos.z, 0f, offset);
        float noiseX = Mathf.PerlinNoise(Time.time / freq, 0f);
        float noiseY = Mathf.PerlinNoise((Time.time + noiseOffset) / freq, 0f);
        float remapedNoiseX = noiseX.Remap(0f, 1f, -calcOffset, calcOffset);
        float remapedNoiseY = noiseY.Remap(0f, 1f, -calcOffset, calcOffset);
        float step =  speed * Time.deltaTime;
        transform.position = new Vector3(transform.position.x + remapedNoiseX , transform.position.y + remapedNoiseY, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }

}
