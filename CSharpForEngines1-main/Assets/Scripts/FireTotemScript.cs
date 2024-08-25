using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTotemScript : MonoBehaviour
{

    public GameObject m_Explosion;

    public GameObject[] explosions;

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
            Explode();
        }
    }

    void Explode()
    {
        Instantiate(m_Explosion, transform.position, Quaternion.identity); //creates an explosion object at its location
        TopDownCharacterController.health--;

        explosions = GameObject.FindGameObjectsWithTag("Explosion");

        foreach (GameObject thisExplosion in explosions)
        {
             Destroy(thisExplosion, 2); //destroys the explosion after 2 seconds
        }



    } 
}
