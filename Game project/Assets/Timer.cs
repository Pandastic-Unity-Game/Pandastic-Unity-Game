using UnityEngine;

// Include the namespace required to use Unity UI
using UnityEngine.UI;

using System.Collections;

public class Timer : MonoBehaviour {

    
    private float startTime;
    public Text timerText;
    private bool showTimer = false;
    private bool finished = false;
   

    void Start()
    {

    }

    
    void Update() { 
    
        if(showTimer)
        {
            
            LapTimer();
        }
      
    }

    void FixedUpdate()
    {
        
    }

  
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Start"))
        {
            print("A");
           // 
            startTime = Time.time;
            showTimer = true;
            timerText.color = Color.white;

        }
        if(other.gameObject.CompareTag("Finnish"))
        {
            timerText.color = Color.yellow;
            showTimer = false;
            print("Finisas veikia");
       
        }
        
    }

    // Timer Script 
    public void LapTimer()
    {
        
       
        float t = Time.time - startTime;

        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        timerText.text = minutes + ":" + seconds;
    }
    public void Finish()
    {
        timerText.color = Color.yellow;
    }

	
}