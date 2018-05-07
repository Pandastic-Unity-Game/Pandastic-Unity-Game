using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unparrent : MonoBehaviour {

	void Start () {
        gameObject.transform.parent = null;
    }
}
