using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{

    public float timeValue = 90;
    public TextMeshProUGUI timerText;
    public float minutes;
    public float seconds;
    public float centiseconds;

    // Update is called once per frame
    void Update()
    {
        if (timeValue > 0 && !GameManager.Instance.isFinished && GameManager.Instance.isPlaying)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            //timeValue = 0;
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
}
