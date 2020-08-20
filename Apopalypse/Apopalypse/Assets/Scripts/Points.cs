using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points : MonoBehaviour
{
    float dist;
    float earnedPoints;
    GameObject player;
    public float zPos;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        dist = Vector3.Distance(player.transform.position, transform.position);
        earnedPoints = dist.Remap(0f, zPos, 0f, 100f);
        earnedPoints = Mathf.FloorToInt(earnedPoints);
        GetComponent<TextMesh>().text = earnedPoints.ToString();
        Score.updatedScore += (int)earnedPoints;
        // GetComponent<TextMesh>().text = "Boom!";
    }

    public void DestroyIt() {
        Destroy(this.gameObject);
    }

}
