using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalGameManager : MonoBehaviour
{
    // 場面の切り替え
    // スコアの管理
    // ゲームの流れを管理
    // CPUの設定
    [SerializeField] GameObject[] localObj = default;
    [SerializeField] LocalPitcherManager localPitcherManager = default;

    public void Init()
    {
        localPitcherManager.Init();
    }

    public void SetActiveObj(bool isActive)
    {
        foreach (GameObject obj in localObj)
        {
            obj.SetActive(isActive);
        }
    }

    // 打たれるまで実行する
    public void PlayAction()
    {
        Invoke(nameof(RequestPitch), 0.5f);
    }

    public void Begin()
    {
        Invoke(nameof(RequestPitch), 0.5f);
    }


    // ピッチャーに球を要求する
    void RequestPitch()
    {
        localPitcherManager.currentPitherData.pitcherObj.GetComponent<LocalPitcher>().Pitch();
    }

    public LocalPitcher GetCurrentPitcher()
    {
        return localPitcherManager.currentPitherData.pitcherObj.GetComponent<LocalPitcher>();
    }

    public LevelData GetCurrentLevelData()
    {
        return localPitcherManager.currentPitherData;
    }

}
