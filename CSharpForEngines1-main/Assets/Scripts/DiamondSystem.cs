using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondSystem : MonoBehaviour
{
    //allows diamonds to be collected

    public static int diamondCount = 0;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject); //destroys the diamond
            diamondCount++; //increases diamond count (shown on UI)

            ScoreSystem.AddScore(1000); //increases score by 1000
        }

    }
}
