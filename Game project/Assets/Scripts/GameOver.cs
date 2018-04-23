using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    // Use this for initialization
    public void restartgame()
    {

        Time.timeScale = 1f;
        SceneManager.LoadScene("Map2");

        Debug.Log("tikrinu");
    }

    // Update is called once per frame
    public void exitgame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}

