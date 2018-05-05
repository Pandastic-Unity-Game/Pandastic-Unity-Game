using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class race2 : MonoBehaviour {

    public bool GameIsStarted = true;
    public bool check = false;
    public GameObject GameOverMenuUI;
    public int tik;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GameIsStarted)
        {
            Pause();

            Debug.Log("started");
        }
	}

    void Pause()
    {
        GameOverMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsStarted = false;
    }
}
