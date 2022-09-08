using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    /*
        Takes Care Of Everything That Is Not UI
     */
    // Managers
    public UIManager UI;
    public SoundManager SM;

    public GameObject CrateGameObject;
    public GameObject LightHouseGameObject;

    public Timer timer;
    public BestTimeTracker BTT;

    public List<Transform> EasySpawnLocations = new List<Transform>();
    public List<Transform> MediumSpawnLocations = new List<Transform>();
    public List<Transform> HardSpawnLocations = new List<Transform>();

    public float CrateCount;
    public float BombCount;
    public float LightHouseCount;

    public float crateClickedCount = 0;
    public float FlagsClickedCount = 0;

    public bool EasyMode = false;
    public bool MediumMode = false;
    public bool HardMode = false;

    public bool B_GameOver = false;
    public bool GameWon = false;

    public bool HideMenu = true;

    // Update is called once per frame
    void Update()
    {
        if (crateClickedCount == CrateCount)
        {
            GameWin();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape Clicked!");
            UI.Pause();
        }
    }
    public void GameStart()
    {
        HideMenu = false;
        switch (PlayerPrefs.GetString("Difficulty", "Normal"))
        {
            case "Easy":
                EasyMode = true; MediumMode = false; HardMode = false;
                break;
            case "Normal":
                EasyMode = false; MediumMode = true; HardMode = false;
                break;
            case "Hard":
                EasyMode = false; MediumMode = false; HardMode = true;
                break;
        }
        timer.ResetTimer();
        crateClickedCount = 0;
        if (EasyMode)
        {
            LightHouseCount = 8;
            CrateCount = 20;
            BombCount = 10;
            EasyGameStart();
        }
        else if (MediumMode)
        {
            LightHouseCount = 5;
            CrateCount = 30;
            BombCount = 20;
            MediumGameStart();
        }
        else if (HardMode)
        {
            LightHouseCount = 3;
            CrateCount = 40;
            BombCount = 30;
            HardGameStart();
        }
        timer.StartStopTimer(true);
    }
    public void GameOver()
    {
        B_GameOver = true;
        timer.PauseTime = true;
        Debug.Log("Lowering GameOver Menu");
        UI.GameOverMenu.SetActive(true);
        UI.GameOverAnimaton.Play("TransDown");
    }
    public void GameWin()
    {
        B_GameOver = true;
        GameWon = true;
        Debug.Log("GameWin!");
        timer.StartStopTimer(false);
        if (EasyMode)
        {
            BTT.SetEasyHighScore(timer.TenMinuteTime, timer.minuteTime, timer.TenSecondTime, timer.secondTime);
        }else if(MediumMode)
        {
            BTT.SetMediumHighScore(timer.TenMinuteTime, timer.minuteTime, timer.TenSecondTime, timer.secondTime);
        }else if(HardMode)
        {
            BTT.SetHardHighScore(timer.TenMinuteTime, timer.minuteTime, timer.TenSecondTime, timer.secondTime);
        }
        UI.GameWinMenu.SetActive(true);
        UI.GameWinAnimation.Play("TransDown");
    }
    public void ClearScene()
    {
        GameObject[] allCrates = GameObject.FindGameObjectsWithTag("Crate");
        foreach (GameObject obj in allCrates)
        {
            Destroy(obj);
        }
        GameObject[] allLighthouses = GameObject.FindGameObjectsWithTag("Lighthouse");
        foreach (GameObject obj in allLighthouses)
        {
            Destroy(obj);
        }
        GameStart();
    }
    private void EasyGameStart()
    {
        PlacesCrate();
        // Places Lighthouses
        for (int i = 0; i < LightHouseCount; i++)
        {
            Vector3 pos = new Vector3();
            pos = EasySpawnLocations[i].position;
            Instantiate(LightHouseGameObject).transform.position = pos;
        }
    }
    private void MediumGameStart()
    {
        PlacesCrate();
        // Places Lighthouses
        for (int i = 0; i < LightHouseCount; i++)
        {
            Vector3 pos = new Vector3();
            pos = MediumSpawnLocations[i].position;
            Instantiate(LightHouseGameObject).transform.position = pos;
        }
    }
    private void HardGameStart()
    {
        PlacesCrate();
        // Places Lighthouses
        for (int i = 0; i < LightHouseCount; i++)
        {
            Vector3 pos = new Vector3();
            pos = HardSpawnLocations[i].position;
            Instantiate(LightHouseGameObject).transform.position = pos;
        }
    }
    void PlacesCrate()
    {
        // Places Crates
        for (int i = 0; i < CrateCount; i++)
        {
            Instantiate(CrateGameObject).gameObject.GetComponent<Crate>().isBomb = false;
        }
        // Plates Bombs
        for (int i = 0; i < BombCount; i++)
        {
            Instantiate(CrateGameObject).gameObject.GetComponent<Crate>().isBomb = true;
        }
    }
}