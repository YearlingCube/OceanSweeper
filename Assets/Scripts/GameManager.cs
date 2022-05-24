using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject CrateGameObject;
    public GameObject LightHouseGameObject;

    public List<Transform> EasySpawnLocations = new List<Transform>();
    public List<Transform> MediumSpawnLocations = new List<Transform>();
    public List<Transform> HardSpawnLocations = new List<Transform>();

    public float CrateCount;
    public float BombCount;
    public float LightHouseCount;
    public float minDistance = 0.4202043f * 3f;

    public bool EasyMode = false;
    public bool MediumMode = false;
    public bool HardMode = false;

    public bool B_GameOver = false;



    // Start is called before the first frame update
    void Start()
    {
        if (EasyMode)
        {
            LightHouseCount = 8;
            EasyGameStart();
        }else if(MediumMode)
        {
            LightHouseCount = 5;
            MediumGameStart();
        }
        else if(HardMode)
        {
            LightHouseCount = 3;
            HardGameStart();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver()
    {
        Debug.Log("GameOver!");
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