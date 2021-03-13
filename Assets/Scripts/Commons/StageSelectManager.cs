using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class StageSelectManager : MonoBehaviour
{
    public static int Clear;
    [SerializeField]
    private int Clear_view;

    [SerializeField] GameObject Select1;
    [SerializeField] GameObject Select2;
    [SerializeField] GameObject Select3;
    [SerializeField] GameObject Select4;
    [SerializeField] GameObject Select5;
    [SerializeField] GameObject Select6;
    [SerializeField] GameObject Select7;
    [SerializeField] GameObject Select8;

    public GameObject[] SelectStage;

    void Awake()
    {
        Clear = Clear_view; 
    }
    private void Start()
    {
        SoundManager.instance.PlayBGM(SoundManager.BGM.StageSelect);

        Clear = ES3.Load<int>("Stagekey", defaultValue: 0);
        Debug.Log("ステージ:" + Clear);
        if (Clear == 0)
        {
            Clear = 1;
            ES3.Save<int>("Stagekey", Clear);
            Debug.Log("初期設定完了");
        }

       

        Debug.Log("ステージ" + Clear);

        if (Clear > 0)
        {
            for(int i = 0;i < Clear; i++)
            {
                SelectStage[i].SetActive(true);
            }

        }

    }
    public void OnEasyButton()
    {
        GameDataManager.instance.SetLevel(Level.Easy);
    }

    public void OnNormalButton()
    {
        GameDataManager.instance.SetLevel(Level.Normal);
    }

    public void OnHardButton()
    {
        GameDataManager.instance.SetLevel(Level.Hard);
    }

    public void OnDebugButton()
    {
        GameDataManager.instance.SetLevel(Level.Debug);
    }

    public void OnStage1Button()
    {
        GameDataManager.instance.SetLevel(Level.Stage1);
    }
    public void OnStage2Button()
    {
        GameDataManager.instance.SetLevel(Level.Stage2);
    }
    public void OnStage3Button()
    {
        GameDataManager.instance.SetLevel(Level.Stage3);
    }
    public void OnStage4Button()
    {
        GameDataManager.instance.SetLevel(Level.Stage4);
    }
    public void OnStage5Button()
    {
        GameDataManager.instance.SetLevel(Level.Stage5);

    }
    public void OnStage6Button()
    {
        GameDataManager.instance.SetLevel(Level.Stage6);

    }
    public void OnStage7Button()
    {
        GameDataManager.instance.SetLevel(Level.Stage7);

    }
    public void OnStage8Button()
    {
        GameDataManager.instance.SetLevel(Level.Stage8);

    }
}
