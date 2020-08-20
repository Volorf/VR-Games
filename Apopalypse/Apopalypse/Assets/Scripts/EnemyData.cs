using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public Vector3 pos;
    public Color enemyColor;

    // todo set enemy itself color from this

    void Awake()
    {
        pos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }
}
