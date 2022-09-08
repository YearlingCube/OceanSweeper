using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;
using UnityEngine.UI;
using System;

public class Settings : MonoBehaviour
{

    public double Volume = 1;

    public Slider VolumeSlider;
    public TextMeshProUGUI VolumeValueText;

    public void Update()
    {
        Volume = Math.Round(VolumeSlider.value, 2);
        VolumeValueText.text = Volume.ToString();
        //AudioSettings.
    }
    public void SetVolume()
    {
        Volume = VolumeSlider.value;
    }
}
