using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject bat;
    [SerializeField] GameObject ball;
    [SerializeField] GameObject bat_display;

    // 補間の強さ（0f～1f） 。0なら追従しない。1なら遅れなしに追従する。
    [SerializeField, Range(0f, 1f)] private float followStrength;

    void Start()
    {

    }

    bool swing_now = false;
    void Update()
    {
        //マウスにバットを追従させる
        var targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = 0f;
        bat.transform.position = Vector3.Lerp(transform.position, targetPos, followStrength);

        //バットを振る 操作：クリック
        if (Input.GetMouseButton(0) && swing_now == false)
        {
            swing_now = true;
        }

        //バットを振るときの動作
        if(bat.transform.rotation.z >= -0.5f && swing_now == true)
        {
            Transform bat_transform = bat.transform;

            bat.transform.Rotate(0, 0, 300.0f * Time.deltaTime);
            bat_display.SetActive(false);
            
        }

        //バットを振り終わった後は元に戻す
        if(bat.transform.rotation.z <= -0.5f)
        {
            bat.transform.rotation = new Quaternion(0, 0, 0,0);
            swing_now = false;
            bat_display.SetActive(true);
        }

    }

}
