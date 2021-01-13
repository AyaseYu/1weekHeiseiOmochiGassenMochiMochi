using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using JetBrains.Annotations;

public class Ball_breakingBall : MonoBehaviour
{
    public int breakingflag;
    private object rectTransform;
    public SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        var sequence = DOTween.Sequence();


        switch (breakingflag) {
            case 1:

                //徐々に早くなる
                sequence.Append(this.transform.DOMove(new Vector3(0f, -8f, 0.3f), 1.5f).SetEase(Ease.InExpo));
                break;

            case 2:
                //横
                sequence.Append(this.transform.DOMove(new Vector3(this.transform.position.x, this.transform.position.y, 0.3f), 0.1f).SetEase(Ease.Linear));
                for (int i = 2;i < 20; i++)
                {
                    if(i % 2 == 0)
                    {
                        sequence.Append(this.transform.DOMove(new Vector3(this.transform.position.x + 2, this.transform.position.y - i, 0.3f), 0.1f).SetEase(Ease.Linear));
                    }
                    else
                    {
                        sequence.Append(this.transform.DOMove(new Vector3(this.transform.position.x - 2, this.transform.position.y - i, 0.3f), 0.1f).SetEase(Ease.Linear));
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
