using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondPotion : MonoBehaviour
{
    [SerializeField] GameObject diamond;
    public Vector2 spawnPoint;

    // Start is called before the first frame update
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            SpawnDiamond();
        }
    }

    void SpawnDiamond()
    {
        spawnPoint = gameObject.transform.position;
        spawnPoint.x -= 2.5f; //offsets spawn position

        Instantiate(diamond, spawnPoint, Quaternion.identity);
    }
}
