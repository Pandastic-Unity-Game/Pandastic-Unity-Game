using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCurrentPosition : MonoBehaviour {

    public Text currentPosition;
    public Positions position;

    // Use this for initialization
    void Start () {
        currentPosition.text = "0th";
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
	}
}
