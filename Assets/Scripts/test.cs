using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Steamworks;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        Debug.Log("ボタンが押されました");

        if (SteamManager.Initialized)
        {
            //初期化が成功したらAppIDを表示(480はサンプルのID)
            SteamUserStats.ResetAllStats(true);
            SteamUserStats.RequestCurrentStats();
            Debug.Log($"Steamの初期化成功, AppID : {SteamUtils.GetAppID()}");
        }
        else
        {
            Debug.Log("Steamの初期化失敗");
        }
    }

    public void OnClick_2()
    {
        if (SteamManager.Initialized)
        {

            string playerName = SteamFriends.GetPersonaName();
            Debug.Log(playerName);

            //初期化が成功したらAppIDを表示(480はサンプルのID)
            SteamUserStats.SetAchievement("frist");
            SteamUserStats.StoreStats();

            Debug.Log(SteamUserStats.GetAchievementName(0));
            Debug.Log($"Steamの初期化成功, AppID : {SteamUtils.GetAppID()}");
        }
        else
        {

        }

    }
}
