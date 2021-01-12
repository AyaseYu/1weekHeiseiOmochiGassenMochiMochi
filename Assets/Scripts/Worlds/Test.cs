using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform ball = default;

    private void Start()
    {
        ball.gameObject.SetActive(false);
    }
    public void Pitch()
    {
        ball.gameObject.SetActive(true);
        StartCoroutine(MoveBall());
        Invoke("ShowShadow", 0.1f);
    }

    void ShowShadow()
    {
        ball.GetChild(0).gameObject.SetActive(true);
    }


    IEnumerator MoveBall()
    {
        while (true)
        {
            yield return null;
            ball.position -= Vector3.up * Time.deltaTime * speed;
            ball.localScale += Vector3.one * Time.deltaTime * speed*0.1f;
        }
    }
}
