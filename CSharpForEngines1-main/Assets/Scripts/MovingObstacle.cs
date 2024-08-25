using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    [SerializeField] Transform m_startPoint;
    [SerializeField] Transform m_endPoint;
    [SerializeField] int m_moveSpeed;

    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = m_startPoint;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target.position, m_moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("MovingObstacleWaypoint"))
        {
            ChangeTarget();
        }
        else if (collision.CompareTag("Player"))
        {
        }
    }

    void ChangeTarget()
    {
        if (target == m_startPoint)
        {
            target = m_endPoint;
        }
        else if (target == m_endPoint)
        {
            target = m_startPoint;
        } 
    }
}
