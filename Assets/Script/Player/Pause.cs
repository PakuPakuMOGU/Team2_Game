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
        if (pauseBack != null) pauseBack.gameObject.SetActive(false);
        if (pauseTxt != null) pauseTxt.gameObject.SetActive(false);
    }

    void Update()
    {
        // Shiftキーで一時停止を切り替え
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0f : 1f;

            if (pauseBack != null) pauseBack.gameObject.SetActive(isPaused);
            if (pauseTxt != null) pauseTxt.gameObject.SetActive(isPaused);

            Debug.Log("Pause状態: " + isPaused);
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
}
