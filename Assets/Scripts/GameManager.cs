using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    string[] questions = new string[] { "a", "b", "c" };
    [SerializeField] Text questionText = default;
    [SerializeField] Text messageText = default;
    int currentIndex;
    string answer;

    void Start()
    {
        messageText.text = "";
        ShowQuestion();
    }

    void Update()
    {
        if (Input.GetKeyDown(answer))
        {
            messageText.text = "成功";
            ShowQuestion();
        }
        else if (Input.anyKeyDown)
        {
            messageText.text = "失敗";
            ShowQuestion();
        }
    }

    void ShowQuestion()
    {
        // ランダムに問題を選択
        currentIndex = Random.Range(0, questions.Length);
        answer = questions[currentIndex];
        // 問題を表示
        questionText.text = answer;
    }
}
