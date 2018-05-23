using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROCKETZONESCRIPT : MonoBehaviour {
    private AIPOWERUP PowerScript;

    private bool Found = false;

    private void Start()
    {
        Found = false;
        Invoke("find",0.5f);
    }

    void find()
    {
        PowerScript = transform.parent.GetComponent<AIPOWERUP>();
        Found = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (Found)
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
}
