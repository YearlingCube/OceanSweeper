using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CountDownTimer : MonoBehaviour
{
    public TextMeshProUGUI CountText;
    public Slider CountDownSlider;
    public Canvas Menu;

    public GameManager GM;

    public float CurrentTime = 0;
    public float StartingTime = 10;

    private void Start()
    {
        CurrentTime = StartingTime;
        CountText.text = CurrentTime.ToString();

        CountDownSlider.maxValue = StartingTime;
        CountDownSlider.minValue = 0;
        CountDownSlider.value = CurrentTime;
    }
    private void Update()
    {
        if (GM.CountDownEnabled)
        {
            CurrentTime -= 1 * Time.deltaTime;
            CountText.text = Mathf.Round(CurrentTime).ToString();
            CountDownSlider.value = CurrentTime;
        }
        else
        {
            Start();
        }
        if (Mathf.Round(CurrentTime) == 0)
        {
            GM.Skip();
        }

    }
}
