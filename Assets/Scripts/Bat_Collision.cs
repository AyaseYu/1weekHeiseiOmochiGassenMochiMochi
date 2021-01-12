using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat_Collision : MonoBehaviour
{
    public AudioClip sound1;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("当たりました");
        AudioSource.PlayClipAtPoint(sound1, Camera.main.transform.position,1.0f);
    }
}
