using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Batter : MonoBehaviour
{
    [SerializeField] GameObject bat;
    [SerializeField] GameObject ball;

    Animator animator;
    // 補間の強さ（0f～1f） 。0なら追従しない。1なら遅れなしに追従する。
    [SerializeField, Range(0f, 1f)] private float followStrength;
    // X, Y座標の移動可能範囲
    [System.Serializable]
    public class Bounds
    {
        public float xMin, xMax, yMin, yMax;
    }
    [SerializeField] Bounds bounds;
    public float time;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        //マウスにバットを追従させる
        var targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPos.x = Mathf.Clamp(targetPos.x, bounds.xMin, bounds.xMax);
        targetPos.y = Mathf.Clamp(targetPos.y, bounds.yMin, bounds.yMax);
        targetPos.z = 0f;
        transform.position = Vector3.Lerp(transform.position, targetPos, followStrength);

        time += Time.deltaTime;

        //バットを振る 操作：クリック
        if (Input.GetMouseButtonDown(0) && time > 1.0f)
        {
            //バットを振る動作
            SwingBat();
        }
    }

    void SwingBat()
    {
        animator.SetTrigger("Swing");
        bat.GetComponent<Bat>().CheckHitOfBall();
        time = 0.0f;
    }
}
