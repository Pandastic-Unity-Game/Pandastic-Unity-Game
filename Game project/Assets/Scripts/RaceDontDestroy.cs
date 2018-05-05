using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceDontDestroy : MonoBehaviour {

    public int data;
	// Use this for initialization
    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
