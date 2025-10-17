using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pause : MonoBehaviour
{
    public Image pauseBack;          // 背景画像
    public TextMeshProUGUI pauseTxt; // テキスト (TMPを使う場合)

    void Start()
    {
        // 最初は非表示
        if (pauseBack != null) pauseBack.gameObject.SetActive(false);
        if (pauseTxt != null) pauseTxt.gameObject.SetActive(false);
    }

    void Update()
    {
        if (!ShareVariable.Share.clear)
        {
            // Shiftキーで一時停止を切り替え
            if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
            {
                ShareVariable.Share.stop = !ShareVariable.Share.stop;
                Time.timeScale = ShareVariable.Share.stop ? 0f : 1f;

                if (pauseBack != null) pauseBack.gameObject.SetActive(ShareVariable.Share.stop);
                if (pauseTxt != null) pauseTxt.gameObject.SetActive(ShareVariable.Share.stop);

                Debug.Log("Pause状態: " + ShareVariable.Share.stop);
            }

            // ポーズ中に Esc で終了
            if (ShareVariable.Share.stop && Input.GetKeyDown(KeyCode.Escape))
            {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
            }
        }
    }
}
