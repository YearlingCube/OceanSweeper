using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI TimerText;

    float secondTime = 0;
    float TenSecondTime = 0;
    float minuteTime = 0;
    float TenMinuteTime = 0;

    public bool StartTime = false;
    public bool PauseTime = false;

    // Start is called before the first frame update
    void Start()
    {
        TimerText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        if (StartTime)
        {
            if (!PauseTime)
            {
                secondTime += 1 *  Time.deltaTime;
                if (Mathf.Round(secondTime) == 10)
                {
                    TenSecondTime += 1;
                    secondTime = 0;
                }
                if (Mathf.Round(TenSecondTime) == 6)
                {
                    minuteTime += 1;
                    TenSecondTime = 0;
                }
                if (Mathf.Round(minuteTime) == 10)
                {
                    TenMinuteTime += 1;
                    minuteTime = 0;
                }
                TimerText.text = Mathf.Round(TenMinuteTime).ToString() + Mathf.Round(minuteTime).ToString() + " : " + Mathf.Round(TenSecondTime).ToString() + Mathf.Round(secondTime).ToString();
            }
        }
    }
    public void ResetTimer()
    {
        secondTime = 0;
        TenSecondTime = 0;
        minuteTime = 0;
        TenMinuteTime = 0;
        TimerText.text = Mathf.Round(TenMinuteTime).ToString() + Mathf.Round(minuteTime).ToString() + " : " + Mathf.Round(TenSecondTime).ToString() + Mathf.Round(secondTime).ToString();
    }
    public void StartStopTimer(bool b)
    {
        StartTime = b;
    }
}
