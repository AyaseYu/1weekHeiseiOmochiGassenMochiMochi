using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LocalPitcher : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform ball = default;
    Animator animator;
    Vector3 ballDefaultPosition = default;
    Vector3 ballDefaultScale = default;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        ballDefaultPosition = ball.position;
        ballDefaultScale = ball.localScale;
    }

    void StartGame()
    {
        ball.gameObject.SetActive(false);
        Pitch();
    }

    public void Throw()
    {
        Debug.Log("Throw");
        ball.gameObject.SetActive(true);
        StartCoroutine(MoveBall());
        Invoke("ShowShadow", 0.1f);
    }
    void ResetBallPosition()
    {
        ball.position = ballDefaultPosition;
        ball.localScale = ballDefaultScale;
        ball.gameObject.SetActive(false);
    }
    public void Pitch()
    {
        ResetBallPosition();
        animator.Play("PitcherAnimation");
    }

    void ShowShadow()
    {
        ball.GetChild(0).gameObject.SetActive(true);
    }


    IEnumerator MoveBall()
    {
        while (ball.position.y > -20f && gameObject.activeSelf)
        {
            yield return null;
            ball.position -= Vector3.up * Time.deltaTime * speed;
            ball.localScale += Vector3.one * Time.deltaTime * speed * 0.1f;
        }
        if (gameObject.activeSelf)
        {
            animator.Play("PitcherIdleAnimation");
            yield return new WaitForSeconds(0.5f);
            Pitch();
        }
    }

    private void OnDisable()
    {
        ResetBallPosition();
        StopAllCoroutines();
    }

    private void OnEnable()
    {
        StopAllCoroutines();
        StartGame();
    }
}
