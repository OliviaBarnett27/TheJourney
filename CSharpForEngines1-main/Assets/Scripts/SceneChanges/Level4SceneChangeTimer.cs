using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level4SceneChangeTimer : MonoBehaviour
{
    float timer = 10f;
    public TMPro.TextMeshProUGUI timerLabel;


    // Update is called once per frame
    void Update() //controls timer
    {
        timer -= Time.deltaTime;

        timerLabel.text = timer + " seconds";

        if (timer <= 0)
        {
            ChangeScene();
        }

        SceneManager.sceneLoaded += OnSceneLoaded; 
    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("Level5"); //loads specified scene
    }

    private void OnSceneLoaded(Scene Level5, LoadSceneMode mode)
    {
        GameObject character = GameObject.FindGameObjectWithTag("Player");
        GameObject spawnPoint = GameObject.FindGameObjectWithTag("StartPoint"); //finds the start point object

        character.transform.position = spawnPoint.transform.position; //moves the character to the start point
    }
}
