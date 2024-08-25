using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript_Wizard : MonoBehaviour
{
    [SerializeField] GameObject m_wizardBullet;
    [SerializeField] float m_projectileSpeed;
    public GameObject myPlayer;
    int wizardHits;
    int basePointsOnDestroy;

    private float cooldown = 0f;

    void Start()
    {
        myPlayer = GameObject.FindGameObjectWithTag("Player");

        m_projectileSpeed = 10;
    }

    // Update is called once per frame
    void Update()
    { 
         cooldown -= Time.deltaTime; //so that projectiles do not fire with on every frame

        if (cooldown <= 0)
        {
            Fire();
        }
    }


    void Fire()
    {
        float customZValue = 10f;

        Vector2 fireDirection = myPlayer.transform.position - this.transform.position; //fires towards the player
    

        GameObject bulletToSpawn = Instantiate(m_wizardBullet, transform.position, Quaternion.identity);

        if (bulletToSpawn.GetComponent<Rigidbody2D>() != null)
        {
            bulletToSpawn.GetComponent<Rigidbody2D>().AddForce(fireDirection.normalized * m_projectileSpeed, ForceMode2D.Impulse);
            cooldown = 1f;
        }
    }
}
