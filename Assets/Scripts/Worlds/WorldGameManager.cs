using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// namespaceで囲むとフォルダわけを行うことができる。
namespace World
{
    public class WorldGameManager : MonoBehaviour
    {
        [SerializeField] Transform homeBaseTransform = default;
        [SerializeField] Ball ball = default;
        [SerializeField] Text distanceText = default;

        private void Start()
        {
            distanceText.text = "";

        }

        // 地面についたときに距離をはかるもの：BallのOnGroundに登録している
        public void CheckDistance()
        {
            float distance = Vector2.Distance(homeBaseTransform.position, ball.transform.position);
            distanceText.text = string.Format("{0:F0}m", distance);
        }
    }
}
