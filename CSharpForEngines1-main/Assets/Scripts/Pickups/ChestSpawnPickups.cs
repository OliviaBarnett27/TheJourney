using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestSpawnPickups : MonoBehaviour
{
    public GameObject[] PickupsArray;
    public Vector2 spawnPoint;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerProjectile")) //if hit by a player projectile
        {
            SpawnPickups();
        }
    }

    void SpawnPickups()
    {
        GameObject currentPickup;

        System.Random random = new System.Random();

        int numberOfPickups = random.Next(1, 5); //the number of pickups spawned will be random between 1 and 4

        int randomPickupToSpawn;

        spawnPoint = gameObject.transform.position; //gets location of chest

        for (int i = 1; i <= numberOfPickups; i++)
        {
            randomPickupToSpawn = random.Next(0, 7); //random between 0 and 6, used to index the array

            currentPickup = PickupsArray[randomPickupToSpawn];

            spawnPoint.x += i/5f + i/10f; //offsets the spawn location so the pickups dont spawn on top of other objects

            Instantiate(currentPickup, spawnPoint, Quaternion.identity);
        }
    }
}
