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
        const int HOMERUN_DISTANCE = 20;
        [SerializeField] GameObject[] worldObj = default;
        public UnityAction<bool> OnGroundOfBall = default;


        public void SetActiveObj(bool isActive)
        {
            foreach (GameObject obj in worldObj)
            {
                obj.SetActive(isActive);
            }
            distanceText.text = "";
            messageText.text = "";
        }


        public void Begin()
        {
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
            bool isHomerun = false;

            float distance = Vector2.Distance(homeBaseTransform.position, ball.transform.position);
            distanceText.text = string.Format("{0:F0}m", distance);
            if (BallIsFoul())
            {
                messageText.text = "ファール！";
            }
            else if (distance > HOMERUN_DISTANCE)
            {
                isHomerun = true;
                messageText.text = "ホームラン！";
            }
            yield return new WaitForSeconds(1f);
            ball.ResetBallPosition();
            OnGroundOfBall.Invoke(isHomerun);
        }

        // 地面についたときに距離をはかるもの：BallのOnGroundに登録している
        public bool BallIsFoul()
        {
            // 角度を取得:Vector2.up,,,つまり、中心線から何度ballがズレているのか取得できる
            float angle = Vector2.Angle(Vector2.up, ball.transform.position);
            Debug.Log(angle);
            // Abs:絶対値,,,単に大きさを求めるもの. |-2|も2も2となる
            return Mathf.Abs(angle) > 62;
        }

    }
}
