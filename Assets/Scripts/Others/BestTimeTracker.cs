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
    float AmountTime = 0;
    public void SetHighScore(float TenMin, float Min, float TenSec, float Sec)
    {
        NewAmountTime = ((TenMin * 60) * 10) + (Min * 60) + (TenSec * 10) + Sec;
        if (NewAmountTime > AmountTime)
        {
            TimerText.text = Mathf.Round(TenMin).ToString() + Mathf.Round(Min).ToString() + " : " + Mathf.Round(TenSec).ToString() + Mathf.Round(Sec).ToString();
            PlayerPrefs.SetString("BestTime", TimerText.text);
            PlayerPrefs.Save();
        }
    }
    // TODO : Set Up Different Best Times For Each Difficulty
}