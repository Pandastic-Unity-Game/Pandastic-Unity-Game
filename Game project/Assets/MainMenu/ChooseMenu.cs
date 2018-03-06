using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseMenu : MonoBehaviour {

	public void SinglePlayerStart()
    {
        SceneManager.LoadScene("Main");
    }

    public void MultiPlayerStart()
    {
        SceneManager.LoadScene("MP");
    }
}
