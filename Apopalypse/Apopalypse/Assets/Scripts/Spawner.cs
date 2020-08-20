using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public float xRange = 20f;
    public float y = 1f;
    public float zPos = 20f;
    public float spawnSpeed = 1f;

    public GameObject [] enemy;

    void Start()
    {
         StartCoroutine("GenerateEnemy");  
    }

    IEnumerator GenerateEnemy() {
        while(true) {
            int ranInd = Random.Range(0, enemy.Length); 
            float x = Random.Range(xRange, -xRange);
            Instantiate(enemy[ranInd], new Vector3(x, y, zPos), Quaternion.identity);
            yield return new WaitForSeconds(spawnSpeed);
        }
    }

}
