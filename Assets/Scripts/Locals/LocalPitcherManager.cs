using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPitcherManager : MonoBehaviour
{
    [SerializeField] PitcherData[] pitchersData = new PitcherData[3];

    private void Start()
    {
        int level = (int)GameDataManager.instance.level;
        Debug.Log(level);
        ShowPitcherOf(level);
    }

    void ShowPitcherOf(int index)
    {
        foreach (PitcherData pitcher in pitchersData)
        {
            pitcher.gameObj.SetActive(false);
        }

        pitchersData[index].gameObj.SetActive(true);
    }
}


[System.Serializable]
public class PitcherData
{
    public Level level;
    public GameObject gameObj;
}
