using UnityEngine;
using TMPro;

public class ClearTime : MonoBehaviour
{
    [Header("Textオブジェクト")]
    public GameObject score_object;

    private TextMeshProUGUI score_text;
    private float elapsedTime = 0f;

    void Start()
    {
        Application.targetFrameRate = 60;
        score_text = score_object.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (!ShareVariable.Share.stop && !ShareVariable.Share.clear)
        {
            elapsedTime += Time.deltaTime;

            int totalSeconds = Mathf.FloorToInt(elapsedTime);
            int hours = totalSeconds / 3600;
            int minutes = (totalSeconds % 3600) / 60;
            int seconds = totalSeconds % 60;

            score_text.SetText($"{hours:D2}:{minutes:D2}:{seconds:D2}");
        }
    }

    public float ReturnNowTime()
    {
        return elapsedTime;
    }

    public void GiveNowTime(float time)
    {
        elapsedTime = time;
    }
}