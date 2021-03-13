using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Level
{
    Easy,
    Normal,
    Hard,
    Debug,
    Stage1,
    Stage2,
    Stage3,
    Stage4,
    Stage5,
    Stage6,
    Stage7,
    Stage8,
}

public class GameDataManager : MonoBehaviour
{
    // データの管理
    // ・難易度の設定



    public Level level = Level.Stage1;

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

    //セーブ
    public static int Clearflag;


}
