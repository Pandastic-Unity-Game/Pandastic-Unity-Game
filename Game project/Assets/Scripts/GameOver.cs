using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private GameObject Decision;

    private void Start()
    {
        Decision = GameObject.FindGameObjectWithTag("Datas");
    }
    // Use this for initialization
    public void restartgame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Map2");
    }

    // Update is called once per frame
    public void exitgame()
    {
        Time.timeScale = 1f;
        Destroy(Decision);
        SceneManager.LoadScene("Menu");
    }
}

