using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricExplosion : MonoBehaviour {

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Player")
        {
            if (!other.GetComponent<My_Power_UP>().ShieldOn)
            {
                other.GetComponent<My_Power_UP>().isElectrified = true;
            }
        }

        if (other.transform.tag == "AI")
        {
            if (!other.GetComponent<AIPOWERUP>().ShieldOn)
            {
                other.GetComponent<AIPOWERUP>().isElectrified = true;
            }
        }

        if (other.transform.tag == "Mine")
        {
            other.GetComponent<Mina>().Destroy();
        }
    }
}
