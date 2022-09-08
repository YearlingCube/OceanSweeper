using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BestTimeTracker : MonoBehaviour
{
    /*
     * Keeps Track Of Players Best Times
     */
    [SerializeField] float BestTime;
    public TextMeshProUGUI TimerText;

    float NewAmountTime = 0;
    float EasyTime = 0;
    float MediumTime = 0;
    float HardTime = 0 ;

    public void SetEasyHighScore(float TenMin, float Min, float TenSec, float Sec)
    {
        NewAmountTime = ((TenMin * 60) * 10) + (Min * 60) + (TenSec * 10) + Sec;
        if (NewAmountTime > EasyTime)
        {
            TimerText.text = Mathf.Round(TenMin).ToString() + Mathf.Round(Min).ToString() + " : " + Mathf.Round(TenSec).ToString() + Mathf.Round(Sec).ToString();
            PlayerPrefs.SetString("BestEasyTime", TimerText.text);
            PlayerPrefs.Save();
        }

    }
    public void SetMediumHighScore(float TenMin, float Min, float TenSec, float Sec)
    {
        NewAmountTime = ((TenMin * 60) * 10) + (Min * 60) + (TenSec * 10) + Sec;
        if (NewAmountTime > MediumTime)
        {
            TimerText.text = Mathf.Round(TenMin).ToString() + Mathf.Round(Min).ToString() + " : " + Mathf.Round(TenSec).ToString() + Mathf.Round(Sec).ToString();
            PlayerPrefs.SetString("BestMediumTime", TimerText.text);
            PlayerPrefs.Save();
        }

    }
    public void SetHardHighScore(float TenMin, float Min, float TenSec, float Sec)
    {
        NewAmountTime = ((TenMin * 60) * 10) + (Min * 60) + (TenSec * 10) + Sec;
        if (NewAmountTime > HardTime)
        {
            TimerText.text = Mathf.Round(TenMin).ToString() + Mathf.Round(Min).ToString() + " : " + Mathf.Round(TenSec).ToString() + Mathf.Round(Sec).ToString();
            PlayerPrefs.SetString("BestHardTime", TimerText.text);
            PlayerPrefs.Save();
        }

    }
}