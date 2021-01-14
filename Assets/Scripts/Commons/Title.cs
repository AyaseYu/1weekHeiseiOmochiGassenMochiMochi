using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title : MonoBehaviour
{
    void Start()
    {
        SoundManager.instance.PlayBGM(SoundManager.BGM.Title);
    }
}
