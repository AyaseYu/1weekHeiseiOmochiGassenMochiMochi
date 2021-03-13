using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// namespaceで囲むとフォルダわけを行うことができる。このクラスを使いたい場合は using World;を上につけるといい。
namespace World
{
    public class Ball : MonoBehaviour
    {
        // 横の角度：ファールになるかどうかなどわかる
        [Range(2.0f, 160.0f)]
        [SerializeField] float initAngle = default;
        // 初速度：(x,y):(水平方向,垂直方向)
        [SerializeField] Vector2 initVelocity = default;

        [SerializeField] GameObject ballObj = default;

        float initTime;

        // 地面に着いたときに実行したい関数を外部から入れる
        public UnityEvent OnGround = default; 


        // デバッグ用：ランダムに角度を変えたい場合に使える
        [Header("デバッグ用")]
        [SerializeField] bool isRandom = default;

        Vector3 ballDefaultPosition = default;
        Vector3 ballObjDefaultPosition = default;
        Vector3 ballObjDefaultScale = default;


        void Awake()
        {
            ballDefaultPosition = transform.position;
            ballObjDefaultPosition = ballObj.transform.position;
            ballObjDefaultScale = ballObj.transform.localScale;
        }

        public void ResetBallPosition()
        {
            ballObj.transform.localScale = ballObjDefaultScale;
            ballObj.transform.position = ballObjDefaultPosition;
            transform.position = ballDefaultPosition;

        }

        public void Setup(float angle, float meetDistance)
        {
            // meetDistance:0〜2: 30から10
            ResetBallPosition();
            // Setup(angle, new Vector2(Mathf.Abs(20 - 10 * meetDistance), 13 - meetDistance * 5));
            // Setup(angle, new Vector2(Mathf.Abs(20 - 10 * meetDistance), 13 - meetDistance * 5));
            //バットごとの値変更　案：initVeloctyに値をかける
            float initVelocityX = Mathf.Abs(15 - 8 * meetDistance);
            float initVelocityy = Mathf.Abs(13 - 4 * meetDistance);
            Debug.Log(initVelocityX+","+initVelocityX);
            Setup(angle, new Vector2(initVelocityX, initVelocityy)); // ホームラン
            // Setup(angle, new Vector2(10, 10)); // ホームラン
        }


        void Setup(float angle, Vector2 velocity)
        {
            if (isRandom)
            {
                initAngle = (Random.Range(20.0f, 160.0f) / 180.0f) * Mathf.PI;
                initVelocity = new Vector2(Random.Range(5.0f, 20.0f), Random.Range(5.0f, 20.0f));
            }
            else
            {
                initAngle = (angle / 180.0f) * Mathf.PI;
                initVelocity = velocity;
            }
        }

        public void Move()
        {
            StartCoroutine(BallMove());
        }



        IEnumerator BallMove()
        {
            // 移動開始時間
            initTime = Time.time;
            // 横の移動方向
            Vector2 direction = new Vector2(Mathf.Cos(initAngle), Mathf.Sin(initAngle));

            // ボールが、影に着くまで移動させる
            while (transform.position.y + 0.01f < ballObj.transform.position.y)
            {
                yield return null;
                MoveHorizontalOfBall(initVelocity.x, direction);
                MoveVerticalOfBall(initVelocity.y, initTime);
            }
            // 地面についたら外部関数を実行:計測判定
            OnGround.Invoke();
        }

        // 水平移動は等速直線運動
        void MoveHorizontalOfBall(float velocityX, Vector2 direction)
        {
            // 影とボールを同時に移動させるから、親オブジェクトである自分自身を移動させる
            transform.position += (Vector3)direction * velocityX * Time.deltaTime;
        }

        // 垂直移動は放物線運動
        void MoveVerticalOfBall(float velocityY, float initTime)
        {
            // 移動量:vt-9.8t^2/2
            float diff = velocityY* Time.deltaTime - 1.5f*9.8f * (Time.time - initTime) * Time.deltaTime / 2f;

            ballObj.transform.position += Vector3.up * diff;
            ballObj.transform.localScale += Vector3.one * diff;

        }

    }
}