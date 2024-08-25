using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    GameObject m_Player;
    public float m_speed;
    public float m_stoppingDistance;
    bool m_PlayerInSight = false;
    public Transform m_sightRadius;

    float fixRotation = 0f;

    NavMeshAgent m_Agent;

    // Start is called before the first frame update
    void Start()
    {
        m_Agent = GetComponent <NavMeshAgent>();

        m_Player = FindObjectOfType<TopDownCharacterController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        m_Agent.SetDestination(m_Player.transform.position);

        transform.rotation = Quaternion.Euler(270, 0, 0); //fixes the rotation of the enemy so that it doesn't flip onto the wrong axis

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerProjectile"))
        {
            Destroy(gameObject);
            ScoreSystem.AddScore(100); // Use the AddScore method to update the score
        }

        m_PlayerInSight = true;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        m_PlayerInSight = false;
    }
}
