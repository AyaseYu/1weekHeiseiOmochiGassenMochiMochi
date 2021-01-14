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
    public SpriteRenderer shadow;
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
                ballList.Add(0);
                ballList.Add(0);
                ballList.Add(3);
                break;
            case Level.Normal:
                ballList.Add(0);
//                ballList.Add(0);
                ballList.Add(1);
                ballList.Add(2);
                ballList.Add(3);
                ballList.Add(4);
                break;
            case Level.Hard:
                ballList.Add(0);
                ballList.Add(1);
                ballList.Add(2);
                ballList.Add(3);
                ballList.Add(4);
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
        Shot(ballList[r]);
    }
    void Shot(int breakingflag)
    {
        float x = Random.Range(-2.0f, 2.0f);
        sequence = DOTween.Sequence();


        switch (breakingflag)
        {
            case 0:
                break;
            case 1:
                //徐々に早くなる
                sequence.Append(this.transform.DOMove(new Vector3(x, 3f, 0), 0.7f).SetEase(Ease.InExpo));
                break;

            case 2:
                //横
                sequence.Append(this.transform.DOMove(new Vector3(this.transform.position.x + x, this.transform.position.y - 4, 0), 0.5f).SetEase(Ease.Linear));
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
                sequence.Append(sr.DOFade(0, 0.4f));
                sequence.Join(shadow.DOFade(0, 0.4f));
                sequence.Join(this.transform.DOMove(new Vector3(x, -9f, 0.3f), 1.5f).SetEase(Ease.Linear));
                break;
            case 4:
                //徐々に早くなる
                sequence.Append(this.transform.DOMove(new Vector3(x, -9f, 0), 1f).SetEase(Ease.InExpo));
                break;

            case 5:
                //横
                sequence.Append(this.transform.DOMove(new Vector3(this.transform.position.x+ x, this.transform.position.y - 4, 0), 0.5f).SetEase(Ease.Linear));
                for (int i = 4; i < 25; i++)
                {
                    if (i % 2 == 0)
                    {
                        sequence.Append(this.transform.DOMove(new Vector3(this.transform.position.x + 2, this.transform.position.y - i, 0), 0.1f).SetEase(Ease.Linear));
                        sequence.Append(this.transform.DOMove(new Vector3(this.transform.position.x, this.transform.position.y - i+1, 0), 0.2f).SetEase(Ease.Linear));
                    }
                    else
                    {
                        sequence.Append(this.transform.DOMove(new Vector3(this.transform.position.x - 2, this.transform.position.y - i, 0), 0.1f).SetEase(Ease.Linear));
                        sequence.Append(this.transform.DOMove(new Vector3(this.transform.position.x, this.transform.position.y - i-1, 0), 0.2f).SetEase(Ease.Linear));
                    }

                }

                break;

        }
        sequence.Play();
    }
}
