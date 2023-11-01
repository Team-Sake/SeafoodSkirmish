using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timeValue = 30;
    public bool timerIsRunning = false;
    public TextMeshProUGUI timeText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartTimer()
    {
        timerIsRunning = true;
    }

    public void SetTimer(float time)
    {
        timeValue = time;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeValue > 0)
            {
                timeValue -= Time.deltaTime;
            }
            else
            {
                Debug.Log("Time has run out!");
                timeValue = 0;
                timerIsRunning = false;
            }
            DisplayTime(timeValue);
        }
        
    }

    void DisplayTime(float timeToDisplay)
    {
        if(timeToDisplay < 0) {
            timeToDisplay = 0;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);

        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:0}:{1:00}", minutes, seconds);

    }
}
