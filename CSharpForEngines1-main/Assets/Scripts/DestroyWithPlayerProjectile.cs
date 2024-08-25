using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWithPlayerProjectile : MonoBehaviour
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
        int chestHealth = 100;
        if (collision.gameObject.CompareTag("PlayerProjectile"))
        {
            //----- to make chest take 3 hits to destroy. might implement later
            /*if (this.gameObject.CompareTag("Chest"))
            {
                if (chestHealth <= 0)
                {
                    Destroy(gameObject);
                }
                else
                {
                    chestHealth -= 34; 
                }

            }*/
            //-----

            Destroy(gameObject);
        }

    }
}
