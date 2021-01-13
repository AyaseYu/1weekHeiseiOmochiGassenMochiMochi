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
    [SerializeField] GameObject rankingButton = default;


    public void SetLevel(LevelData levelData)
    {
        SetBallCount(levelData.pitchingCount);
        SetHomerunCount(0);
        SetNorma(levelData.clearScore);
        bool isHardMode = levelData.level == Level.Hard || levelData.level == Level.Debug;
        SetHardMode(isHardMode);
    }

    void SetHardMode(bool isHardMode)
    {
        ballCount.gameObject.SetActive(!isHardMode);
        rankingButton.gameObject.SetActive(isHardMode);
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
