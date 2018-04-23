using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCurrentPosition : MonoBehaviour {

    public Text currentPosition;
    public Positions position;
    public string tag;
    // Use this for initialization
    void Start () {
		currentPosition = GetComponent<Text>();
        currentPosition.text = "0";
        
    }
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < position.carOrder.Length; i++)
        {
            if (position.carOrder[i].tag == tag)
            {
                currentPosition.text = (i + 1).ToString();
            }
        }
	}
}
