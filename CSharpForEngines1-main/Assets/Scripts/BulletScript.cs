using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        string thisTag = gameObject.tag;

        if (other.CompareTag("Wall"))  
        {
            Destroy(gameObject); //destroys projectiles if they hit walls
        }

        if (thisTag == "PlayerProjectile")
        {

            if (other.CompareTag("Wizard"))
            {
                Destroy(other.gameObject); //destroy enemy
                Destroy(gameObject); //destroy projectile
                ScoreSystem.AddScore(250); //increases score
            }
            else if (other.CompareTag("Zombie") || other.CompareTag("FireTotem"))
            {
                Destroy(other.gameObject); //destroy enemy
                Destroy(gameObject); //destroy projectile
                ScoreSystem.AddScore(500); //increases score
            }
        }
        else if (thisTag == "EnemyProjectile")
        {
            if (other.CompareTag("Player"))
            {
                Destroy(gameObject); //destroys the enemy projectile
                TopDownCharacterController.health--; //reduces player health by 1
            }
        }
    }
}
