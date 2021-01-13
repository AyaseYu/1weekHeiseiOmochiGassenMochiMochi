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

    public float time;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        //マウスにバットを追従させる
        var targetPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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
        bat.GetComponent<BoxCollider2D>().enabled = true;
        time = 0.0f;
        Invoke("ResetCollider", 0.2f);
    }

    private void ResetCollider()
    {
        bat.GetComponent<BoxCollider2D>().enabled = false;
    }
}
