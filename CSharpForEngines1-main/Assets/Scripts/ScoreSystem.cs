using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{

    public static int score = 0;

    public static void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
    }

    public static int GetScore()
    {
        return score;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
