using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

// namespaceで囲むとフォルダわけを行うことができる。このクラスを使いたい場合は using World;を上につけるといい。
namespace World
{
    public class WorldGameManager : MonoBehaviour
    {
        [SerializeField] Transform homeBaseTransform = default;
        [SerializeField] Ball ball = default;
        [SerializeField] Text distanceText = default;
        [SerializeField] Text messageText = default;

        [SerializeField] Bat bat = default;
        const int HOMERUN_DISTANCE = 32;
        [SerializeField] GameObject[] worldObj = default;
        public UnityAction<bool> OnGroundOfBall = default;
        [SerializeField] GameObject debugObj = default;

        bool isHomerun;
 
        public void SetActiveObj(bool isActive)
        {
            foreach (GameObject obj in worldObj)
            {
                obj.SetActive(isActive);
            }
            distanceText.text = "";
            messageText.text = "";
        }

        private void Update()
        {
            // float distance = Vector2.Distance(homeBaseTransform.position, debugObj.transform.position);
        }

        public void Begin()
        {
            isHomerun = false;
            SetActiveObj(true);
            ball.Move();
        }
        // ボールの初期設定

        // 地面についたときに距離をはかるもの：BallのOnGroundに登録している
        public void CheckDistance()
        {
            StartCoroutine(CheckResult());
        }

        IEnumerator CheckResult()
        {
            float distance = Vector2.Distance(homeBaseTransform.position, ball.transform.position);
            // 21:120
            // 0:0
            // distanceText.text = string.Format("{0:F0}m", 120*distance/21);
            if (BallIsFoul())
            {
                messageText.text = "ファール！";
            }
            else if (distance > HOMERUN_DISTANCE || isHomerun)
            {
                isHomerun = true;
                messageText.text = "ホームラン！";
            }
            yield return new WaitForSeconds(1f);
            ball.ResetBallPosition();
            OnGroundOfBall.Invoke(isHomerun);
            isHomerun = false;
        }

        // 地面についたときに距離をはかるもの：BallのOnGroundに登録している
        public bool BallIsFoul()
        {
            // 角度を取得:Vector2.up,,,つまり、中心線から何度ballがズレているのか取得できる
            float angle = Vector2.Angle(Vector2.up, ball.transform.position);
            // Abs:絶対値,,,単に大きさを求めるもの. |-2|も2も2となる
            return Mathf.Abs(angle) > 70;
        }


        private void OnTriggerEnter2D(Collider2D collision)
        {

            if (collision.CompareTag("Finish"))
            {
                Debug.Log("ホームラン");
                isHomerun = true;
            }
        }
    }
}
