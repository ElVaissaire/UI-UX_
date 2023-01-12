using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{

    public float timeInit = 90;
    public TextMeshProUGUI timerText;
    public float minutes;
    public float seconds;
    public float centiseconds;

    public delegate void NoMoreTime();
    public static event NoMoreTime OnTimeFinished;

    private float timeValue;

    private void Start()
    {
        timeValue = timeInit;
    }
    // Update is called once per frame
    void Update()
    {
        if(!GameManager.Instance.isFinished && GameManager.Instance.isPlaying)
        {
            if(timeValue > 0)
            {
                timeValue -= Time.deltaTime;
            }
            else
            {
                timeValue = 0;
            }
        }

        if(timeValue == 0)
        {
            print("gameover");
            OnTimeFinished();
        }

        DisplayTime(timeValue);
    }

    void DisplayTime (float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }

        minutes = Mathf.FloorToInt(timeToDisplay / 60);
        seconds = Mathf.FloorToInt(timeToDisplay % 60);
        centiseconds = timeToDisplay % 1 * 100;

        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, centiseconds);
    }

    public void RestartTimer()
    {
        timeValue = timeInit;
    }
}
