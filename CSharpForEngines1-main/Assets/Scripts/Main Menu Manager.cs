using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{

    public GameObject m_Panel;

    public GameObject m_player;
    public GameObject m_UIcanvas;

    public void PlayButton()
    {
        SceneManager.LoadScene("Level1");
        GameObject.Instantiate(m_UIcanvas);
        GameObject.Instantiate(m_player);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
