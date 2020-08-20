using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathDetector : MonoBehaviour
{
    
    GameObject points;
    GameObject explosion;
    EnemyData enemyData;
    bool gavePoints = false;
    float zPos;

    void Awake() 
    {
    }

    void Start() 
    {   
        enemyData = transform.GetComponent<EnemyData>();
        zPos = enemyData.pos.z;

        points = Resources.Load("Points", typeof(GameObject)) as GameObject;
        points.GetComponent<Points>().zPos = zPos;

        explosion = Resources.Load("Explosion", typeof(GameObject)) as GameObject;
        // explosion.GetComponent<Explosion>().color = enemyData.enemyColor;
        
        
    }

    void  OnTriggerEnter(Collider other) 
    {
        ListenToShot(other.tag);
    }

    public void ListenToShot(string tag) 
    {
        if (tag == "Needle") 
        {
            // Show points
            if(!gavePoints) {
                
                GameObject pointGO = Instantiate(points, transform.position + new Vector3(0,2.5f,0), Quaternion.LookRotation(transform.position - Camera.main.transform.position));
                GameObject explosionGO = Instantiate(explosion, transform.position, Quaternion.identity);
                explosionGO.GetComponent<Explosion>().color = enemyData.enemyColor;
                
                gavePoints = true;
            }
            Destroy(this.gameObject);
        }
    }

}
