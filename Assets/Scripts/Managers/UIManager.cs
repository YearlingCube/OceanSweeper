using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    /*
        Takes Care Of All Game UI
     */
    // GameManager
    public GameManager GM;
    public SoundManager SM;

    // Menus
    public GameObject GameOverMenu;
    public GameObject GameWinMenu;
    public GameObject PauseMenu;
    public GameObject GameMenu;
    public GameObject DiffMenu;

    // Animators
    public Animator GameOverAnimaton;
    public Animator GameWinAnimation;
    public Animator DiffMenuAnimation;
    public Animator FadeAnimation;

    // Game UI Texts
    public TextMeshProUGUI FlagCountText;
    public TextMeshProUGUI CrateCountText;

    // Variables
    bool isPaused = false;

    public void Update()
    {
        CrateCountText.text = "- " + (GM.CrateCount - GM.crateClickedCount).ToString();
        FlagCountText.text = "- " + (GM.BombCount - GM.FlagsClickedCount).ToString();

        if (GM.HideMenu)
            GameMenu.SetActive(false);
        else
            GameMenu.SetActive(true);
    }

    #region MenuButtons
    public void Retry()
    {
        GM.B_GameOver = false;
        GM.timer.ResetTimer();
        GM.ClearScene();
        GM.FlagsClickedCount = 0;
        if (GM.GameWon)
        {
            GameWinAnimation.Play("TransUp");
            GM.GameWon = false;
        }
        else
            GameOverAnimaton.Play("TransUp");

        GM.timer.PauseTime = false;
    }
    IEnumerator LoadMainMenu()
    {
        Time.timeScale = 1;
        FadeAnimation.Play("FadeOut");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene("MainMenu");

    }
    public void MainMenu()
    {
        StartCoroutine(LoadMainMenu());
    }
    public void Resume()
    {
        Time.timeScale = 1;
        GM.timer.PauseTime = false;
        PauseMenu.SetActive(false);
        isPaused = false;
    }
    public void Pause()
    {
        if (!isPaused)
        {
            Time.timeScale = 0;
            GM.timer.PauseTime = true;
            PauseMenu.SetActive(true);
            isPaused = true;
        }
        else
        {
            isPaused = false;
            Resume();
        }
    }
    public void SetDifficultyEasy()
    {
        PlayerPrefs.SetString("Difficulty", "Easy");
        DiffMenuAnimation.Play("TransUp");
        GM.GameStart();
    }
    public void SetDifficultyNormal()
    {
        PlayerPrefs.SetString("Difficulty", "Normal");
        DiffMenuAnimation.Play("TransUp");
        GM.GameStart();
    }
    public void SetDifficultyHard()
    {
        PlayerPrefs.SetString("Difficulty", "Hard");
        DiffMenuAnimation.Play("TransUp");
        GM.GameStart();
    }
    public void MouseClick()
    {
        SM.PlaySound("Select");
    }
    #endregion
}
