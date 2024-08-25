using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;



public class SpawnPickups : MonoBehaviour
{

    public struct PossiblePickups
    {
        public string pickupName;
        public int spawnProbability;
        public Sprite pickupSprite;
    }
    public Vector2 areaToSpawn;
    public int numberOfPickups;
    [SerializeField] GameObject pickup;
    public Vector3 randomLocation;
    public Sprite testSprite;

    public PossiblePickups[] PossiblePickupsArray = new PossiblePickups[10];

    public Sprite heart;
    public Sprite pointsBoost;
    public Sprite emptyHeart;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        randomLocation.z = 0;
        System.Random random = new System.Random();
        if (collision.gameObject.CompareTag("PlayerProjectile"))
        {
            areaToSpawn = gameObject.transform.position; //gets location of chest
            numberOfPickups = random.Next(1,5); //how many pickups should be spawned
            int randomPickup;

            for (int i = 1; i <= numberOfPickups; i++)
            {
                randomPickup = random.Next(0, 8);
//                pickup = PossiblePickupsArray[randomPickup];
            }

            double randomCoordinate;
            float randomCoordinateFloat;

            //----- used to decide whether the random coordinate should be added or subtracted from the chest's coordinate
            int addOrSubtract = random.Next(0, 1);
            bool isAdd;

            if (addOrSubtract == 0)
            {
                isAdd = false;
            }
            else
            {
                isAdd = true;
            }
            //-----

            for (int i = 0; i < numberOfPickups; i++)
            {
                randomCoordinate = random.NextDouble(); //picks a random double between 0 and 1 that is used to get the new coordinate of a pickup
                addOrSubtract = random.Next(0, 1);


                if (addOrSubtract == 0)
                {
                    randomLocation.x = (areaToSpawn.x + (float)randomCoordinate)/2f; //adds the random coordinate
                }
                else
                {
                    randomLocation.x = (areaToSpawn.x - ((float)randomCoordinate)/2f); //subtracts the random coordinate
                }

                randomCoordinate = random.NextDouble(); //picks a random double between 0 and 1 that is used to get the new coordinate of a pickup
                addOrSubtract = random.Next(0, 1);

                if (addOrSubtract == 0)
                {
                    randomLocation.y = (areaToSpawn.y + ((float)randomCoordinate)/2f); //adds the random coordinate
                }
                else
                {
                    randomLocation.y = (areaToSpawn.y - ((float)randomCoordinate)/2f); //subtracts the random coordinate
                }

                Instantiate(pickup, transform.position + randomLocation, Quaternion.identity);

            }
        }

    }
}
