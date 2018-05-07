using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCurrentPosition : MonoBehaviour {

    public Text currentPosition;
    public Positions position;

    private GameOverMenu GOMenu;
    private Text PositionText;
    private Text DeathText;

    private bool set = false;

    // Use this for initialization
    void Start () {
        currentPosition.text = "0th";
        GOMenu = GameObject.FindGameObjectWithTag("InGameMenu").GetComponent<GameOverMenu>();
        set = false;
    }
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < position.carOrder.Length; i++)
        {
            if (position.carOrder[i].tag == "Player")
            {
                if (i+1 == 1)
                {
                    currentPosition.text = (i + 1).ToString()+"st";
                }
                else if (i+1 == 2)
                {
                    currentPosition.text = (i + 1).ToString() + "nd";
                }
                else if (i+1 == 3)
                {
                    currentPosition.text = (i + 1).ToString() + "rd";
                }
                else
                {
                    currentPosition.text = (i + 1).ToString() + "th";
                }
            }
        }

        if (GOMenu.GameIsOver && !set)
        {
            PositionText = GameObject.FindGameObjectWithTag("GOPosition").GetComponent<Text>();
            PositionText.text = currentPosition.text;
            set = true;
        }
	}
}
