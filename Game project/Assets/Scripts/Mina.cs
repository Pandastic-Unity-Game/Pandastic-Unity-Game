using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mina : MonoBehaviour {

   
	void Start () {
      
	}
	
	// Update is called once per frame
	void Update () {
        
	}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player" || collision.transform.tag == "AI")
        {
            Destroy(this.gameObject);
        }
        
    }
}
