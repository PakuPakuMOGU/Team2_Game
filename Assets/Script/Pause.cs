using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pause : MonoBehaviour
{
    public Image pauseBack;          // 背景画像
    public TextMeshProUGUI pauseTxt; // テキスト (TMPを使う場合)

    private bool isPaused = false;

    void Start()
    {
        // 最初は非表示
        SetAlpha(pauseBack, 0f);
        SetAlpha(pauseTxt, 0f);
    }

    void Update()
    {
        // Shiftキーで一時停止を切り替え
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            isPaused = !isPaused;
            Debug.Log("Pause状態: " + isPaused);

            if (isPaused)
            {
                Time.timeScale = 0f; // 停止
                SetAlpha(pauseBack, 1f);
                SetAlpha(pauseTxt, 1f);
            }
            else
            {
                Time.timeScale = 1f; // 再開
                SetAlpha(pauseBack, 0f);
                SetAlpha(pauseTxt, 0f);
            }
        }

        // ポーズ中に Esc で終了
        if (isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }

    // 透明度を即座に変更
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