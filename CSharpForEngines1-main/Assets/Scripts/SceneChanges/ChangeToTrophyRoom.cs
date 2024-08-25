using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToTrophyRoom : MonoBehaviour
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
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject[] zombies = GameObject.FindGameObjectsWithTag("Zombie");
            GameObject[] wizards = GameObject.FindGameObjectsWithTag("Wizard");
            GameObject[] firetotems = GameObject.FindGameObjectsWithTag("FireTotem");
            //GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

            // Check if no actors with the specified tag were found
            if (zombies.Length == 0 && wizards.Length == 0 && firetotems.Length == 0)
            {
                SceneManager.LoadScene("TrophyRoom");
            }
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene TrophyRoom, LoadSceneMode mode)
    {
        GameObject character = GameObject.FindGameObjectWithTag("Player");
        GameObject spawnPoint = GameObject.FindGameObjectWithTag("StartPoint");

        character.transform.position = spawnPoint.transform.position;
    }
}