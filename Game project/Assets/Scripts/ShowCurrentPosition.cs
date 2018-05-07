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

    private Positions Positions;

    // Use this for initialization
    void Start () {
        currentPosition.text = "0th";
        GOMenu = GameObject.FindGameObjectWithTag("InGameMenu").GetComponent<GameOverMenu>();
        set = false;

        Positions = GameObject.FindGameObjectWithTag("InGameMenu").GetComponent<Positions>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Positions.playerPos == 1)
        {
            currentPosition.text = "1st";
        }
        else if (Positions.playerPos == 2)
        {
            currentPosition.text = "2nd";
        }
        else if (Positions.playerPos == 3)
        {
            currentPosition.text = "3rd";
        }
        else
        {
            currentPosition.text = Positions.playerPos.ToString() + "th";
        }

        if (GOMenu.GameIsOver && !set)
        {
            PositionText = GameObject.FindGameObjectWithTag("GOPosition").GetComponent<Text>();
            PositionText.text = currentPosition.text;
            set = true;
        }
	}
}
