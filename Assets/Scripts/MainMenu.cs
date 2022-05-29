using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayClick()
    {
        SceneManager.LoadScene("Game");
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
        Debug.Log("Settings Clicked!");
    }
    public void CreditsClick()
    {
        Debug.Log("Credits Clicked!");
    }
}
