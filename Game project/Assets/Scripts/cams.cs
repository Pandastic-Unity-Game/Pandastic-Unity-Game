using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cams : MonoBehaviour
{

    private bool isSelect = false;

    private Vector3 FrontP = new Vector3(0, 0, 20);

    void Update()
    {
        if (Input.GetButtonDown("Front"))
        {
            if (isSelect)
            {
                transform.localPosition -= FrontP;
                transform.rotation *= Quaternion.Euler(0, 180, 0);
                isSelect = false;
            }
            else
            {
                transform.localPosition += FrontP;
                transform.rotation *= Quaternion.Euler(0, 180, 0);
                isSelect = true;
            }
        }
    }
}