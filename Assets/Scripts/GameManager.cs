using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMB;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject bat_object;
    [SerializeField] GameObject bat;
    [SerializeField] GameObject ball;
    [SerializeField] GameObject bat_display_transparent;
    [SerializeField] GameObject bat_display;

    // 補間の強さ（0f～1f） 。0なら追従しない。1なら遅れなしに追従する。
    [SerializeField, Range(0f, 1f)] private float followStrength;

    public float time;
    void Start()
    {
        //タイム初期値
        time = 1.0f;

        //ランキング　スコア
        //naichilab.RankingLoader.Instance.SendScoreAndShowRanking(100);
    }

    void Update()
    {
        //マウスにバットを追従させる
        var targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.z = 0f;
        bat_object.transform.position = Vector3.Lerp(transform.position, targetPos, followStrength);

        time += Time.deltaTime;

            //バットを振る 操作：クリック
            if (Input.GetMouseButtonDown(0) && time > 1.0f)
            {
                //バットを振る動作
                bat.SetActive(false);
                bat_display.SetActive(true);
                time = 0.0f;

             }
            
            if(time > 0.2f)
            {

                bat.SetActive(true);
                bat_display.SetActive(false);

            }

         

    }

}
