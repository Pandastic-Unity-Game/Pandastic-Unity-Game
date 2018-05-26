using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using UnityEditor.TestTools;
using System;
using UnityEditor.TestTools.TestRunner;
using UnityEngine;
using UnityEngine.UI;


public class TEST
{


    Button press1;
    GameObject tikrinti1;

    Button press2;
    GameObject tikrinti2;

    Button press3;
    GameObject tikrinti3;

    Button press21;
    GameObject tikrinti21;

    Button press22;
    GameObject tikrinti22;

    Button press31;
    GameObject tikrinti31;

    Button press14;
    GameObject tikrinti14;

    Button press141;
    GameObject tikrinti141;

    Button press2b;
    GameObject tikrinti2b;


    Button press1o;
    GameObject tikrinti1o;

    Dropdown pressor;
    GameObject tikrintior;


    // A UnityTest behaves like a coroutine in PlayMode
    // and allows you to yield null to skip a frame in EditMode





    [UnityTest]
    public IEnumerator Direct()
    {

        SetupScene();
        yield return new WaitForSeconds(2);
        tikrinti1 = GameObject.FindGameObjectWithTag("1");
        press1 = tikrinti1.GetComponent<Button>();
        press1.onClick.Invoke();

        yield return new WaitForSeconds(2);


        tikrinti2 = GameObject.FindGameObjectWithTag("select");
        press2 = tikrinti2.GetComponent<Button>();
        press2.onClick.Invoke();

        yield break;

        tikrinti3 = GameObject.FindGameObjectWithTag("race");
        press3 = tikrinti3.GetComponent<Button>();
        press3.onClick.Invoke();


        yield return new WaitForSeconds(20);

        // Assert.Fail();
        /* SetupScene();
         if (GameObject.Find("Car").GetComponent<Rigidbody>().velocity.sqrMagnitude < .0001)
         {
             yield break;
         }*/
    }


    [UnityTest]
    public IEnumerator Changed()
    {
        SetupScene();
        yield return new WaitForSeconds(2);
        tikrinti1 = GameObject.FindGameObjectWithTag("1");
        press1 = tikrinti1.GetComponent<Button>();
        press1.onClick.Invoke();

        yield return new WaitForSeconds(2);
        tikrinti21 = GameObject.FindGameObjectWithTag("lap+");
        press21 = tikrinti21.GetComponent<Button>();
        press21.onClick.Invoke();
        press21.onClick.Invoke();
        press21.onClick.Invoke();

        yield return new WaitForSeconds(1);
        tikrinti22 = GameObject.FindGameObjectWithTag("op+");
        press22 = tikrinti22.GetComponent<Button>();
        press22.onClick.Invoke();
        press22.onClick.Invoke();

        yield return new WaitForSeconds(1);
        tikrinti2 = GameObject.FindGameObjectWithTag("select");
        press2 = tikrinti2.GetComponent<Button>();
        press2.onClick.Invoke();

        yield break;

        tikrinti3 = GameObject.FindGameObjectWithTag("race");
        press3 = tikrinti3.GetComponent<Button>();
        press3.onClick.Invoke();


        yield return new WaitForSeconds(20);

        Assert.Fail();
    }

    [UnityTest]
    public IEnumerator Quit()
    {        
        SetupScene();
        yield return new WaitForSeconds(2);

        tikrinti14 = GameObject.FindGameObjectWithTag("quit");
        press14 = tikrinti14.GetComponent<Button>();
        press14.onClick.Invoke();
        yield return new WaitForSeconds(2);

        tikrinti141 = GameObject.FindGameObjectWithTag("yes");
        press141 = tikrinti141.GetComponent<Button>();
        press141.onClick.Invoke();
    

        yield return new WaitForSeconds(2);
        yield break;
         
    }

    [UnityTest]
    public IEnumerator BackOptions()
    {
        SetupScene();
        yield return new WaitForSeconds(2);
        tikrinti1 = GameObject.FindGameObjectWithTag("1");
        press1 = tikrinti1.GetComponent<Button>();
        press1.onClick.Invoke();

        yield return new WaitForSeconds(2);
        tikrinti2b = GameObject.FindGameObjectWithTag("back");
        press2b = tikrinti2b.GetComponent<Button>();
        press2b.onClick.Invoke();

        yield return new WaitForSeconds(2);
        tikrinti1o = GameObject.FindGameObjectWithTag("options");
        press1o = tikrinti1o.GetComponent<Button>();
        press1o.onClick.Invoke();

        yield return new WaitForSeconds(2);
        tikrintior = GameObject.FindGameObjectWithTag("resolu");
        pressor = tikrintior.GetComponent<Dropdown>();
        pressor.Show();
        yield return new WaitForSeconds(1);
        pressor.value = 3;

        yield return new WaitForSeconds(2);
        yield break;

    }


    void SetupScene()
    {

        SceneManager.LoadScene("Assets/Scenes/Menu.unity");
        //MonoBehaviour.Instantiate(GameObject.Find(Spawn));

        /*MonoBehaviour.Instantiate(Resources.Load<GameObject>("Spawns"));
        MonoBehaviour.Instantiate(Resources.Load<GameObject>("SCENE"));
        MonoBehaviour.Instantiate(Resources.Load<GameObject>("Canvas"));*/

    }
}
