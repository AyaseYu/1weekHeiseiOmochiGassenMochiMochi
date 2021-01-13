using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSelectManager : MonoBehaviour
{
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

}
