using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToScene4 : MonoBehaviour
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
            System.Random random = new System.Random();
            int chooseLevel = random.Next(1, 3);
            Debug.Log(chooseLevel);
            if (chooseLevel == 1)
            {
                SceneManager.LoadScene("Level4A");
            }
            else
            {
                SceneManager.LoadScene("Level4B");

            }

        }
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene level, LoadSceneMode mode)
    {
        GameObject character = GameObject.FindGameObjectWithTag("Player");
        GameObject spawnPoint = GameObject.FindGameObjectWithTag("StartPoint");

        character.transform.position = spawnPoint.transform.position;
    }
}
