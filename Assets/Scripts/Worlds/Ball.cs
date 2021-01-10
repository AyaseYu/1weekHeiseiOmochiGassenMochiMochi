using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// namespaceで囲むとフォルダわけを行うことができる。
namespace World
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] float speed = default;
        [Range(2.0f, 160.0f)]
        [SerializeField] float angle = default;
        [SerializeField] GameObject ballObj = default;
        [SerializeField] bool isRandom = default;

        [SerializeField] float ballScale = default;

        public UnityEvent OnGround = default; // 地面に着いたときに実行したい関数を外部から入れる

        const int UP = 1;
        const int DOWN = -1;

        bool canMove = true;
        void Start()
        {
            Init();
        }

        void Init()
        {
            if (isRandom)
            {
                angle = (Random.Range(20.0f, 160.0f) / 180.0f) * Mathf.PI;
            }
            else
            {
                angle = (angle / 180.0f) * Mathf.PI;
            }
            StartCoroutine(BallMove());
        }

        void Update()
        {
            if (canMove)
            {
                Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
                MoveShadow(direction);
            }
        }

        void MoveShadow(Vector2 direction)
        {
            transform.position += (Vector3)direction * speed * Time.deltaTime;
        }


        IEnumerator BallMove()
        {
            int count = 0;
            while (count < 200)
            {
                count++;
                yield return null;
                MoveBallObj(UP);
            }
            while (transform.position.y + 0.01f < ballObj.transform.position.y)
            {
                yield return null;
                MoveBallObj(DOWN);
            }

            canMove = false;
            OnGround.Invoke();
        }

        void MoveBallObj(int sign)
        {
            ballObj.transform.position += sign * Vector3.up * speed * Time.deltaTime * ballScale;
            ballObj.transform.localScale += sign * Vector3.one * speed * Time.deltaTime * ballScale;
        }

    }
}