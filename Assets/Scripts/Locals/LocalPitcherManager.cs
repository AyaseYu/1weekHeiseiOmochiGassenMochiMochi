using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPitcherManager : MonoBehaviour
{
    [SerializeField] LevelData[] levelList = default;
    public LevelData currentPitherData;

    private void Start()
    {

        int level = (int)GameDataManager.instance.level;
        Debug.Log(level);
        ShowPitcherOf(level);
    }

    void ShowPitcherOf(int index)
    {
        foreach (LevelData level in levelList)
        {
            level.pitcherObj.GetComponent<LocalPitcher>().SetLevel(level);
            level.pitcherObj.SetActive(false);
        }

        levelList[index].pitcherObj.SetActive(true);
        currentPitherData = new LevelData(levelList[index]);
    }
}


[System.Serializable]
public class LevelData
{
    public Level level;
    public GameObject pitcherObj;
    public int pitchingCount;
    public int clearScore;

    public LevelData(LevelData levelData)
    {
        this.level = levelData.level;
        this.pitcherObj = levelData.pitcherObj;
        this.pitchingCount = levelData.pitchingCount;
        this.clearScore = levelData.clearScore;
    }
}
