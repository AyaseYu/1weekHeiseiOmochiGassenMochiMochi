using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bat : MonoBehaviour
{
    public AudioClip sound1;
    [SerializeField] Transform meetPoint;
    public UnityEvent OnCollision = default;
    [SerializeField] World.Ball ball = default;
    [SerializeField] GameObject localBall = default;
    const float offset = 0.1f;
    const int k = 30;
    [SerializeField] int kk = 0;
    public void CheckHitOfBall()
    {
        float dis = localBall.transform.position.y - meetPoint.transform.position.y;
        float angle = 0;
        if (dis < 0.2f + offset || dis > 2.5f + offset)
        {
            Debug.Log("空振り:" + dis);
            return;
        }

        if (dis < 0.4f + offset)
        {
            angle = 20 - (0.4f + offset - dis) * k;
            Debug.Log("振り遅れ:" + dis);
        }
        if (dis < 0.6f+offset)
        {
            angle = 60 - (0.4f + offset-dis) * k;
            Debug.Log("振り遅れ:" + dis);
        }
        else if (dis < 1f + offset)
        {
            angle = 90- (0.8f + offset- dis) * k;
            Debug.Log("ちょうど:" + dis);
        }
        else if (dis < 2.0f + offset)
        {
            angle = 120- (1.5f + offset-dis) * k;
            Debug.Log("速い:" + dis);
        }
        else
        {
            angle = 170 - (2.25f + offset - dis) * k;
            Debug.Log("早すぎ:" + dis);
        }

        // float meedDistance = Vector2.Distance(meetPoint.transform.position, localBall.transform.position);
        float meedDistance = Mathf.Abs(meetPoint.transform.position.x - localBall.transform.position.x) + Mathf.Abs(dis-0.5f) * 0.4f;
        string tmp = string.Format("距離{0}:バットの位置y{1}, ボールの位置{2}", localBall.transform.position.y - meetPoint.transform.position.y, meetPoint.transform.position.y, localBall.transform.position.y);
        string tmp2 = string.Format("ミートの位置{0}, ボールとの距離{1}", (Vector2)meetPoint.transform.position, meedDistance);
        Debug.Log(tmp);
        Debug.Log(tmp2);
        Debug.Log(angle);
        // Debug.Break();
        ball.Setup(angle, meedDistance);
        Invoke("ChangeWorld", 0.1f);
    }

    void ChangeWorld()
    {
        localBall.gameObject.SetActive(false);
        AudioSource.PlayClipAtPoint(sound1, Camera.main.transform.position, 1.0f);
        OnCollision.Invoke();
    }



}
