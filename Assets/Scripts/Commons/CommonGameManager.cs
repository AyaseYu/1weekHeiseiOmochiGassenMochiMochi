﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using World;

public class CommonGameManager : MonoBehaviour
{
    [SerializeField] WorldGameManager worldGameManager = default;
    [SerializeField] LocalGameManager localGameManager = default;
    [SerializeField] GameResult gameResult = default;
    [SerializeField] MainUI mainUI = default;

    Level level;
    int ballCount;
    int homerunCount;
    int missingCount = 0;


    enum ViewMode
    {
        Local,
        World,
    }

    ViewMode currentViewMode;

    bool IsLocalView
    {
        get => currentViewMode == ViewMode.Local;
    }

    private void Start()
    {
        homerunCount = 0;
        localGameManager.Init();
        localGameManager.GetCurrentPitcher().OnCatcherForBall = OnCatcherForBall;
        ballCount = localGameManager.GetCurrentLevelData().pitchingCount;
        worldGameManager.OnGroundOfBall = OnGroundOfBall;
        level = localGameManager.GetCurrentLevelData().level;
        currentViewMode = ViewMode.Local;
        ShowLocal(IsLocalView);// 初めはローカルを表示
        mainUI.SetLevel(localGameManager.GetCurrentLevelData());
        mainUI.SetHomerunCount(homerunCount);
        mainUI.HideResult();
        Invoke("Begin", 0.5f);
    }

    void Begin()
    {
        localGameManager.Begin();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            OnRetry();
        }
    }

    // 切り替えを行う
    public void ShowLocal(bool isActive)
    {
        worldGameManager.SetActiveObj(!isActive);
        localGameManager.SetActiveObj(isActive);
    }

    public void OnCollisionOfBat()
    {
        currentViewMode = ViewMode.World;
        ShowLocal(IsLocalView);// 初めはローカルを表示
        worldGameManager.Begin();
    }

    public void OnCatcherForBall()
    {
        missingCount++;
        ballCount--;
        mainUI.SetBallCount(ballCount);
        mainUI.SetBallCount(ballCount);

        if (IsEnd() || level == Level.Hard && missingCount >= 3)
        {
            ShowResult();
            return;
        }
        localGameManager.Begin();
    }
    void OnGroundOfBall(bool isHomerun)
    {
        if (level == Level.Hard && !isHomerun)
        {
            missingCount++;
        }

        if (missingCount >= 3)
        {
            ShowResult();
            return;
        }
        ballCount--;
        if (isHomerun)
        {
            homerunCount++;
        }
        mainUI.SetBallCount(ballCount);
        mainUI.SetHomerunCount(homerunCount);
        if (IsEnd())
        {
            ShowResult();
            return;
        }
        currentViewMode = ViewMode.Local;
        ShowLocal(IsLocalView);// 初めはローカルを表示
        localGameManager.Begin();
    }

   

    bool IsEnd()
    {
        if (ballCount <= 0)
        {
            return true;
        }
        return IsNormaClear();
    }

    bool IsNormaClear()
    {
        if (homerunCount >= localGameManager.GetCurrentLevelData().clearScore)
        {
            return true;
        }
        return false;
    }

    // 結果の表示を行う
    public void ShowResult()
    {
        if (IsNormaClear())
        {
            mainUI.ShowResult("成功!");
        }
        else
        {
            mainUI.ShowResult("失敗...");
        }
    }

    public void OnRankingButton()
    {
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(homerunCount);
    }

    public void OnTitle()
    {
        SceneManager.LoadScene("Title");
    }
    public void OnRetry()
    {
        SceneManager.LoadScene("Main");
    }
}
