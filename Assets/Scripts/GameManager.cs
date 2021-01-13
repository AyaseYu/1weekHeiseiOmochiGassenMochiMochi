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

    // X, Y座標の移動可能範囲
    [System.Serializable]
    public class Bounds
    {
        public float xMin, xMax, yMin, yMax;
    }
    [SerializeField] Bounds bounds;

    // 補間の強さ（0f～1f） 。0なら追従しない。1なら遅れなしに追従する。
    [SerializeField, Range(0f, 1f)] private float followStrength;

    public float time;
    void Start()
    {
        //タイム初期値
        time = 1.0f;

        //ランキング　スコア
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(120);
    }

    void Update()
    {
        //マウスにバットを追従させる
        var targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.x = Mathf.Clamp(targetPos.x, bounds.xMin, bounds.xMax);
        targetPos.y = Mathf.Clamp(targetPos.y, bounds.yMin, bounds.yMax);
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
