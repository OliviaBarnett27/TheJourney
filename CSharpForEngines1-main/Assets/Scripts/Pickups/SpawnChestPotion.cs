using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChestPotion : MonoBehaviour
{
    [SerializeField] GameObject chest;
    public Vector2 spawnPoint;

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
            SpawnChest();
        }
    }

    void SpawnChest()
    {
        spawnPoint = gameObject.transform.position;
        spawnPoint.x += 1;

        Instantiate(chest, spawnPoint, Quaternion.identity);
    }
}
