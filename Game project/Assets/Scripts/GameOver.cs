using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private GameObject Decision;
    public bool rest;

    private void Start()
    {
        rest = false;
        Decision = GameObject.FindGameObjectWithTag("Datas");
    }
    // Use this for initialization
    public void restartgame()
    {
        rest = true;
        Time.timeScale = 1f;
        SceneManager.LoadScene("Map2");
    }

    // Update is called once per frame
    public void exitgame()
    {
        Time.timeScale = 1f;
        rest = true;
        Destroy(Decision);
        SceneManager.LoadScene("Menu");
    }
}

