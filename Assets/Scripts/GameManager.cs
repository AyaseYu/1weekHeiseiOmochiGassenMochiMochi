using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject bat_object;
    [SerializeField] GameObject bat;
    [SerializeField] GameObject ball;
    [SerializeField] GameObject bat_display_transparent;
    [SerializeField] GameObject bat_display;

    // 補間の強さ（0f～1f） 。0なら追従しない。1なら遅れなしに追従する。
    [SerializeField, Range(0f, 1f)] private float followStrength;

    void Start()
    {

    }

    void Update()
    {
        //マウスにバットを追従させる
        var targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = 0f;
        bat_object.transform.position = Vector3.Lerp(transform.position, targetPos, followStrength);

        //バットを振る 操作：クリック
        if (Input.GetMouseButton(0))
        {
            //バットを振る動作
            bat.SetActive(false);
            bat_display.SetActive(true);
         
        }
        else
        {
            
            bat.SetActive(true);
            bat_display.SetActive(false);
         
        }

    }

}
