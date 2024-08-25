using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillEnemiesPotion : MonoBehaviour
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
            DestroyEnemies();
        }
    }

    void DestroyEnemies()
    {
        GameObject[] enemies;
        enemies = GameObject.FindGameObjectsWithTag("Enemy"); //finds all enemys in level

        foreach (GameObject currentGameObject in enemies)
        {
            Destroy(currentGameObject); //destroys every enemy
        }
    }
}
