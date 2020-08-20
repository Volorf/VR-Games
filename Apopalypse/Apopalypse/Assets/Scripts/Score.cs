using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    TextMesh scoreTextMesh;

    int currentScore;
    public static int updatedScore;

    [SerializeField] int scoreIncrement = 1;

    void Start()
    {
        currentScore = 0;
        updatedScore = 0;
        scoreTextMesh = GetComponent<TextMesh>();
        scoreTextMesh.text = currentScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateScore();
    }
    void UpdateScore() 
    {
        if(currentScore < updatedScore)
        {
            currentScore += scoreIncrement;
            // if(scoreTextMesh != null)
            // {
            //     scoreTextMesh.text = currentScore.ToString();
            // }
        }
        currentScore = updatedScore;
        scoreTextMesh.text = currentScore.ToString();
    }
}
