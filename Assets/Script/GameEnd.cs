using UnityEngine;
using UnityEngine.UI; // Image, Text を使うため

public class Pose : MonoBehaviour
{
    public Image PoseBack;    // 背景画像
    public Text Posetxt;      // テキスト

    private bool isPaused = false;

    void Start()
    {
        // デフォルトで透明にする
        SetAlpha(PoseBack, 0f);
        SetAlpha(Posetxt, 0f);
    }

    void Update()
    {
        // Shiftキーでポーズ切り替え
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            isPaused = !isPaused;

            if (isPaused)
            {
                // 表示
                SetAlpha(PoseBack, 1f);
                SetAlpha(Posetxt, 1f);
                Time.timeScale = 0f; // ゲーム停止
            }
            else
            {
                // 非表示
                SetAlpha(PoseBack, 0f);
                SetAlpha(Posetxt, 0f);
                Time.timeScale = 1f; // ゲーム再開
            }
        }
    }

    // 透明度を即時に変更する関数
    private void SetAlpha(Graphic g, float alpha)
    {
        if (g != null)
        {
            Color c = g.color;
            c.a = alpha;
            g.color = c;
        }
    }
}
