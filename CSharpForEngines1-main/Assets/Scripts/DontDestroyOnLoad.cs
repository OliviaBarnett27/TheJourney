using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //the game object wont be destroyed when the scene changes
        DontDestroyOnLoad(gameObject);
    }
}
