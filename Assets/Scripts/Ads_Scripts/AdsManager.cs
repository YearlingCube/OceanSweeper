using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsManager : MonoBehaviour
{
    GameManager GM;

    InterstitialAds InterAds;
    public float TotalGamesBeforeAds;
    // Start is called before the first frame update
    void Start()
    {
        GM = FindObjectOfType<GameManager>();
        InterAds = FindObjectOfType<InterstitialAds>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Inter Ads " +( GM.GamesCount == TotalGamesBeforeAds && GM.adAvailable));
        if (GM.GamesCount == TotalGamesBeforeAds && GM.adAvailable)
        { 
            InterAds.ShowAd();
        }
    }
}
