using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject CrateGameObject;
    public GameObject LightHouseGameObject;

    public InterstitialAds InterAds;
    public AdsRewarded RewardAds;

    public Canvas SaveYourSelfMenu;
    public Canvas GameOverMenu;
    public Canvas PauseMenu;

    public Timer timer;

    public Animator GameOverAnimaton;
    public Animator SaveYourSelfAnimaton;

    public List<Transform> EasySpawnLocations = new List<Transform>();
    public List<Transform> MediumSpawnLocations = new List<Transform>();
    public List<Transform> HardSpawnLocations = new List<Transform>();

    public TextMeshProUGUI FlagCountText;
    public TextMeshProUGUI CrateCountText;

    public float CrateCount;
    public float BombCount;
    public float LightHouseCount;

    public float crateClickedCount = 0;
    public float FlagsClickedCount = 0;

    public bool EasyMode = false;
    public bool MediumMode = false;
    public bool HardMode = false;

    public bool B_GameOver = false;

    public float GamesCount = 0;

    public bool adAvailable = false;

    public bool FlagMode = false;

    public bool CountDownEnabled = false;


    // Start is called before the first frame update
    void Start()
    {
        timer.ResetTimer();
        crateClickedCount = 0;
        if (EasyMode)
        {
            LightHouseCount = 8;
            CrateCount = 20;
            BombCount = 10;
            EasyGameStart();
        }else if(MediumMode)
        {
            LightHouseCount = 5;
            CrateCount = 30;
            BombCount = 20;
            MediumGameStart();
        }
        else if(HardMode)
        {
            LightHouseCount = 3;
            CrateCount = 40;
            BombCount = 30;
            HardGameStart();
        }
        timer.StartStopTimer(true);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(crateClickedCount);
        if (crateClickedCount == CrateCount)
        {
            GameWin();
        }
        CrateCountText.text = "- " + (CrateCount - crateClickedCount).ToString();
        FlagCountText.text = "- " + (BombCount- FlagsClickedCount).ToString();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            PauseMenu.enabled = !PauseMenu.enabled;
        }
    }
    public void GameOver()
    {
        adAvailable = false;
        B_GameOver = true;
        timer.PauseTime = true;
        Debug.Log("Lowering Ad Menu");
        SaveYourSelfAnimaton.Play("TransIn");
        CountDownEnabled = true;
    }
    public void GameWin()
    {
        B_GameOver = true;
        Debug.Log("GameWin!");
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
        Start();
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
    #region MenuButtons
    public void Retry()
    {
        B_GameOver = false;
        adAvailable = false;
        timer.ResetTimer();
        ClearScene();
        GameOverAnimaton.Play("GameOverUp");

    }
    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    public void Skip()
    {
        SaveYourSelfAnimaton.Play("TransOut");
        CountDownEnabled = false;
        adAvailable = true;
        Debug.Log("Skip : Dropping Game Over Screen");
        GameOverAnimaton.Play("GameOverDropIn");

    }
    public void WatchAd()
    {
        SaveYourSelfAnimaton.Play("TransOut");
        CountDownEnabled = false;
        B_GameOver = false;
        timer.PauseTime = false;
    }
    public void Resume()
    {
        Time.timeScale = 1;
        timer.PauseTime = false;
        PauseMenu.enabled = false;
    }
    public void Pause()
    {
        Time.timeScale = 0;
        timer.PauseTime = true;
        PauseMenu.enabled = true;
    }
    #endregion
}