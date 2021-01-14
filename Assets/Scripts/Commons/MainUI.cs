using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    [SerializeField] Text ballCount = default;
    [SerializeField] Text homerunCount = default;
    [SerializeField] Text norma = default;

    [SerializeField] GameObject resultPanel = default;
    [SerializeField] Text resultText = default;


    public void SetLevel(LevelData levelData)
    {
        SetHomerunCount(0);
        if (levelData.level == Level.Hard)
        {
            SetMissCount(0);
            this.norma.text = string.Format("---");
        }
        else
        {
            SetBallCount(levelData.pitchingCount);
            SetNorma(levelData.clearScore);
        }
    }


    public void SetMissCount(int miss)
    {
        this.ballCount.text = string.Format("ミス:{0}回", miss);
    }


    public void SetBallCount(int ballCount)
    {
        this.ballCount.text = string.Format("残り:{0}球", ballCount);
    }

    public void SetHomerunCount(int homerunCount)
    {
        this.homerunCount.text = string.Format("ホームラン:{0}本", homerunCount);
    }

    void SetNorma(int norma)
    {
        this.norma.text = string.Format("ノルマ:{0}本", norma);
    }

    public void ShowResult(string result)
    {
        resultPanel.SetActive(true);
        resultText.text = result;
    }
    public void HideResult()
    {
        resultPanel.SetActive(false);
    }

}
