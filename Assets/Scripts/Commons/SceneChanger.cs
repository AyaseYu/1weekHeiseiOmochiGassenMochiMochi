using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{

    public void OnNextScene(string nextSceneName)
    {
        SoundManager.instance.PlaySE(SoundManager.SE.Button);
        SceneManager.LoadScene(nextSceneName);
    }
}
