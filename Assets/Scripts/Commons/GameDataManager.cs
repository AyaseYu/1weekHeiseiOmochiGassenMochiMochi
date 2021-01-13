using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Level
{
    Easy,
    Normal,
    Hard,
    Debug,
}

public class GameDataManager : MonoBehaviour
{
    // データの管理
    // ・難易度の設定



    public Level level = Level.Easy;

    public static GameDataManager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetLevel(Level level)
    {
        this.level = level;
    }


}
