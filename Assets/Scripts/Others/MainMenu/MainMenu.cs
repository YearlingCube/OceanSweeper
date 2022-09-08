using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    /*
        Controls Everything In The Main Menu
     */
    public Animator MainMenuAnimations;
    public TextMeshProUGUI bestTime;
    public MainMenuAnimationHandler MAH;
    public GameObject MainCanvas;

    public Canvas CanvSettings;

    public void Start()
    {
        bestTime.text = PlayerPrefs.GetString("BestTime");
        StartCoroutine(MAH.PlayOpening());
    }
    public void PlayClick()
    {
        StartCoroutine(LoadScene("Game"));
    }
    public void QuitClick()
    {
        Debug.Log("Application Quit!");
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
    public void SettingsClick()
    {
        MAH.FadeIn();
        MainCanvas.SetActive(false);
        CanvSettings.enabled = true;
        Debug.Log("Settings Clicked!");
    }
    public void CreditsClick()
    {
        Debug.Log("Credits Clicked!");
    }
    IEnumerator LoadScene(string LevelName)
    {
        // Play Animation
        MainMenuAnimations.Play("FadeOut");
        // Wait
        yield return new WaitForSeconds(1);
        // Load Level
        SceneManager.LoadScene(LevelName);
    }
    public void BackToMain()
    {
        MainCanvas.SetActive(true);
        //StartCoroutine(MAH.FadeMain());
        CanvSettings.enabled = false;
    }
}
