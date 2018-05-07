using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROCKETZONESCRIPT : MonoBehaviour {
    private AIPOWERUP PowerScript;

    private void Start()
    {
        PowerScript = transform.parent.GetComponent<AIPOWERUP>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "LOL" || other.transform.tag == "AI")
        {
            PowerScript.IsRocket = true;
        }
        else
        {
            PowerScript.IsRocket = false;
        }
    }
}
