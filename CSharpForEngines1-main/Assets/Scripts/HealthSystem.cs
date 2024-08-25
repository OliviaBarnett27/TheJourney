using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    static bool isDestroyed = false;

    //handles pickups that alter health

    public void OnTriggerEnter2D(Collider2D collision)
    {
        string thisTag = gameObject.tag;

        if (collision.gameObject.CompareTag("Player"))
        {
            if (thisTag == "HealthPotion")
            {
                ChangeHealth(10);
            }
            else if (thisTag == "Heart")
            {
                ChangeHealth(1);
            }
            else if (thisTag == "DeathPotion")
            {
                ChangeHealth(0);
            }
        }
    }

    void ChangeHealth(int increaseHealth)
    {
        //increaseHealth = 6;
        if (increaseHealth == 1)
        {
            TopDownCharacterController.health++;
        }
        else if (increaseHealth == 10)
        {
            TopDownCharacterController.health = 10;
        }
        else if (increaseHealth == 0)
        {
            TopDownCharacterController.health = 0;
        }

        Debug.Log(TopDownCharacterController.health);
    }
    
}
