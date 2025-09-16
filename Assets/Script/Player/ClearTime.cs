using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearTime : MonoBehaviour
{
    [Header("Textオブジェクト")]
    public GameObject score_object = null;

    private int time = 0;
    private int timeCount = 0;

    void Start()
    {
        Application.targetFrameRate = 60;
    }

    void Update()
    {
        if (timeCount >= 60)
        {
            timeCount = 0;
            time++;

            Text score_text = score_object.GetComponent<Text>();

            int hours = time / 3600;
            int minutes = (time % 3600) / 60;
            int seconds = time % 60;

            score_text.text = $"{hours:D2}:{minutes:D2}:{seconds:D2}"; // 例: 01:23:45
        }
        timeCount++;
    }
}
