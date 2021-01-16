using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    [SerializeField] AudioSource bgm = default;
    [SerializeField] AudioSource se = default;
    [SerializeField] AudioClip[] bgmClips = default;
    [SerializeField] AudioClip[] seClips = default;
    [SerializeField] GameObject settingPanel = default;
    [SerializeField] Image speakerIcon = default;
    [SerializeField] Sprite speakerOnIcon = default;
    [SerializeField] Sprite speakerOffIcon = default;
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
        MainHard,
        Title,
        Main,
        StageSelect,
    }
    public enum SE
    {
        Hit,
        Button,
        Clear,
        GameOver,
    }

    bool isSpeakerOn = true;
    public void OnSpeaker()
    {
        isSpeakerOn = !isSpeakerOn;
        if (isSpeakerOn)
        {
            AudioListener.volume = 0;
            speakerIcon.sprite = speakerOffIcon;
        }
        else
        {
            AudioListener.volume = 1;
            speakerIcon.sprite = speakerOnIcon;
        }

    }

    public void PlayBGM(BGM bgmType)
    {
        int index = (int)bgmType;
        bgm.clip = bgmClips[index];
        if (bgmType == BGM.MainHard)
        {
            bgm.volume = 0.1f;
        }
        else
        {
            bgm.volume = 0.4f;
        }

        bgm.Play();
    }

    public void PlaySE(SE seType)
    {
        if (seType == SE.Clear || seType == SE.GameOver)
        {
            bgm.Stop();
        }
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
