using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Image pauseBack;             // 背景パネル
    public TextMeshProUGUI pauseTxt;    // ポーズ用テキスト
    public Button quitButton;           // Quit ボタン
    public Button optionButton;         // Option ボタン

    private bool isPaused = false;

    void Start()
    {
        // 初期状態は透明に
        SetPauseUI(false);
    }

    void Update()
    {
        // Shift キーでポーズ切替
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            isPaused = !isPaused;
            SetPauseUI(isPaused);
            Time.timeScale = isPaused ? 0f : 1f;  // ポーズ中はゲーム停止
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

    private void SetPauseUI(bool active)
    {
        // 背景は半透明
        if (pauseBack != null)
            SetAlpha(pauseBack, active ? 0.5f : 0f);

        // テキストは完全不透明
        if (pauseTxt != null)
            SetAlpha(pauseTxt, active ? 1f : 0f);

        // ボタンも透明度で管理
        if (quitButton != null)
            SetButtonAlpha(quitButton, active ? 1f : 0f);
        if (optionButton != null)
            SetButtonAlpha(optionButton, active ? 1f : 0f);
    }

    // Graphic の透明度を変更
    private void SetAlpha(Graphic g, float alpha)
    {
        if (g != null)
        {
            Color c = g.color;
            c.a = alpha;
            g.color = c;
        }
    }

    // Button 内の Image と TextMeshProUGUI をまとめて透明度変更
    private void SetButtonAlpha(Button button, float alpha)
    {
        if (button == null) return;

        // ボタン背景 Image
        Image img = button.GetComponent<Image>();
        if (img != null)
            SetAlpha(img, alpha);

        // ボタンのテキスト
        TextMeshProUGUI txt = button.GetComponentInChildren<TextMeshProUGUI>();
        if (txt != null)
            SetAlpha(txt, alpha);

        // ボタン自体の interactable は alpha に応じて切替（任意）
        button.interactable = alpha > 0f;
    }

    // ボタン用メソッド
    public void QuitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void OpenOption()
    {
        Debug.Log("Option画面を開く処理をここに追加");
    }
}
