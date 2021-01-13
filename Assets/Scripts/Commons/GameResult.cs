using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameResult : MonoBehaviour
{

    private void Start()
    {
    }

    public void ShowResult()
    {
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(100);
    }
}
