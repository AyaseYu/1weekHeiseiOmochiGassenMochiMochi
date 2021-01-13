using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JetBrains.Annotations;

public class BallBreaking : MonoBehaviour
{
    public int breakingflag;
    private object rectTransform;
    public SpriteRenderer sr;
    Sequence sequence;

    List<int> ballList = new List<int>();
    public void ResetDoTween()
    {
        sequence.Kill();
    }

    public void Init(Level level)
    {
        switch (level)
        {
            case Level.Easy:
                ballList.Add(0);
                break;
            case Level.Normal:
                ballList.Add(0);
                ballList.Add(1);
                ballList.Add(2);
                break;
            case Level.Hard:
                ballList.Add(0);
                ballList.Add(1);
                ballList.Add(2);
                ballList.Add(3);
                break;
            case Level.Debug:
                ballList.Add(0);
                ballList.Add(1);
                ballList.Add(2);
                ballList.Add(3);
                break;
        }
    }

    public void Shot()
    {
        int r = Random.Range(0, ballList.Count);
        // Shot(ballList[r]);
        Shot(3);
    }
    void Shot(int breakingflag)
    {
        
        sequence = DOTween.Sequence();


        switch (breakingflag)
        {
            case 0:
                break;
            case 1:

                //徐々に早くなる
                sequence.Append(this.transform.DOMove(new Vector3(0f, -8f, 0), 1f).SetEase(Ease.InExpo));
                break;

            case 2:
                //横
                sequence.Append(this.transform.DOMove(new Vector3(this.transform.position.x, this.transform.position.y - 4, 0), 0.5f).SetEase(Ease.Linear));
                for (int i = 4; i < 25; i++)
                {
                    if (i % 2 == 0)
                    {
                        sequence.Append(this.transform.DOMove(new Vector3(this.transform.position.x + 2, this.transform.position.y - i, 0), 0.1f).SetEase(Ease.Linear));
                    }
                    else
                    {
                        sequence.Append(this.transform.DOMove(new Vector3(this.transform.position.x - 2, this.transform.position.y - i, 0), 0.1f).SetEase(Ease.Linear));
                    }

                }

                break;

            case 3:
                //消える
                sequence.Append(sr.DOFade(0, 1));
                sequence.Join(this.transform.DOMove(new Vector3(0f, -8f, 0.3f), 1.5f).SetEase(Ease.InExpo));
                break;
        }
        sequence.Play();
    }
}
