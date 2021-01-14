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
    

    public UnityAction OnCatcherForBall = default;


    LevelData levelData;
    BallBreaking ballBreaking;
    GameObject shadow;
    float addSpeed = 1;
    public void Init()
    {
        animator = GetComponent<Animator>();
        ballDefaultPosition = ball.position;
        ballDefaultScale = ball.localScale;
        ballBreaking = ball.GetComponent<BallBreaking>();
        shadow = ball.transform.GetChild(0).gameObject;
        ballBreaking.Init(levelData.level);
        if (levelData.level == Level.Hard)
        {
            addSpeed = 1.5f;
        }
    }


    public void SetLevel(LevelData levelData)
    {
        this.levelData = new LevelData(levelData);
    }

    /*
    void StartGame()
    {
        ball.gameObject.SetActive(false);
        Pitch();
    }*/

    public void Throw()
    {
        ball.gameObject.SetActive(true);
        StartCoroutine(MoveBall());
        ballBreaking.Shot();
    }
    void ResetBallPosition()
    {
        ballBreaking.ResetDoTween();
        ball.position = ballDefaultPosition;
        ball.localScale = ballDefaultScale;
        ball.GetComponent<SpriteRenderer>().color = Color.white;
        shadow.GetComponent<SpriteRenderer>().color = Color.black;
        ball.gameObject.SetActive(false);
        shadow.SetActive(false);

    }
    public void Pitch()
    {
        ResetBallPosition();
        animator.Play("PitcherAnimation");
    }


    IEnumerator MoveBall()
    {
        while (ball.position.y > -10f && gameObject.activeSelf)
        {
            yield return null;
            if (ball.position.y < 5f && shadow.activeSelf == false)
            {
                shadow.SetActive(true);
            }
            ball.position -= Vector3.up * Time.deltaTime * speed*addSpeed;
            ball.localScale += Vector3.one * Time.deltaTime * speed * 0.1f * addSpeed;
        }
        if (gameObject.activeSelf)
        {
            animator.Play("PitcherIdleAnimation");
            ResetBallPosition();
            yield return new WaitForSeconds(0.5f);
            OnCatcherForBall.Invoke();
        }
    }

    private void OnEnable()
    {
        StopAllCoroutines();
    }
}
