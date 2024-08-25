using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesPotion : MonoBehaviour
{
    public GameObject[] EnemyArray;
    public Vector2 spawnPoint;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SpawnEnemies();
        }
    }

    void SpawnEnemies()
    {
        GameObject currentEnemy;

        System.Random random = new System.Random();

        int numberOfEnemies = random.Next(1, 5); //number of enemies spawned will be random between 1 and 4

        int randomEnemyToSpawn;

        spawnPoint = gameObject.transform.position;

        for (int i = 1; i <= numberOfEnemies; i++)
        {
            randomEnemyToSpawn = random.Next(0, 3); //random number between 0 and 2, used to index array

            currentEnemy = EnemyArray[randomEnemyToSpawn];

            spawnPoint.x += i; //offsets spawn position

            Instantiate(currentEnemy, spawnPoint, Quaternion.identity);
        }


    }
}
