using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CommonGameManager : MonoBehaviour
{
    [SerializeField] World.WorldGameManager worldGameManager = default;
    [SerializeField] LocalGameManager localGameManager = default;
    [SerializeField] GameResult gameResult = default;

    // 切り替えを行う

    public void ShowLocal(bool isActive)
    {

    }

    // 結果の表示を行う
    public void ShowResult()
    {

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
