using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrophyScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Destroy the gameObject this script is attached to
            Destroy(gameObject);


            SceneManager.LoadScene("WinScreen"); //loads the win screen and wins the game

            GameObject character = GameObject.FindGameObjectWithTag("Player");

            Destroy(character); //destroys the player so they cant be controlled on the win screen
        }

    }
}
