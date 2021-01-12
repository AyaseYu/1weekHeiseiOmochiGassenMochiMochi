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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        float offsetY = GetComponent<BoxCollider2D>().offset.y;
        Debug.Log(collision.gameObject.name + ":" + collision.transform.position + "/" + gameObject.name + ":" + transform.position);
        float sideDistance = collision.transform.position.y+0.2f - (transform.position.y + offsetY); // 数値が大きいほど早い振り
        float angle = Mathf.RoundToInt(sideDistance * 180);
        Debug.Log("バットはボールの" + angle + "で当てた");

        float meedDistance = Mathf.Abs(meetPoint.position.x - collision.transform.position.x);
        Debug.Log("ミートからの距離は" + meedDistance);

        AudioSource.PlayClipAtPoint(sound1, Camera.main.transform.position, 1.0f);

        ball.Setup(angle, meedDistance);
        // Debug.Break();
        OnCollision.Invoke();
    }

}
