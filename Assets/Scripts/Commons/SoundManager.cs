using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource bgm = default;
    [SerializeField] AudioSource se = default;
    [SerializeField] AudioClip[] bgmClips = default;
    [SerializeField] AudioClip[] seClips = default;
    [SerializeField] GameObject settingPanel = default;

    public static SoundManager instance;
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

    public enum BGM
    {
        Title,
        Main,
        Result,
    }
    public enum SE
    {
        Hit,
    }

    public void PlayBGM(BGM bgmType)
    {
        int index = (int)bgmType;
        bgm.PlayOneShot(bgmClips[index]);
    }

    public void PlaySE(SE seType)
    {
        int index = (int)seType;
        se.PlayOneShot(seClips[index]);
    }

    public void ShowSettingPanel()
    {
        settingPanel.SetActive(true);
    }

    public void OnCloseSettingPanel()
    {
        settingPanel.SetActive(false);
    }
}
