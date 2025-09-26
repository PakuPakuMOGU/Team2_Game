using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("UI設定")]
    public Image pauseBack;             // 背景パネル
    public TextMeshProUGUI pauseTxt;    // ポーズ用テキスト
    public Button quitButton;           // Quit ボタン
    public Button optionButton;         // Option ボタン

    [Header("効果音設定")]
    public AudioSource audioSource;     // 効果音再生用
    public AudioClip quitSE;            // Quit ボタン用SE
    public AudioClip optionSE;          // Option ボタン用SE
    public AudioClip resumeSE;          // 再開用SE
    public AudioClip pauseSE;           // ポーズON用SE

    private bool isPaused = false;

    void Start()
    {
        // 最初はポーズUIを非表示
        SetPauseUI(false);
    }

    void Update()
    {
        // Shift キーでポーズ切替
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            isPaused = !isPaused;
            SetPauseUI(isPaused);
            Time.timeScale = isPaused ? 0f : 1f;

            // ポーズ/再開のSE再生
            if (isPaused) PlaySE(pauseSE);
            else PlaySE(resumeSE);
        }

        // Escで終了（ポーズ中のみ）
        if (isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    private void SetPauseUI(bool active)
    {
        // 背景とテキストの透明度
        if (pauseBack != null) pauseBack.gameObject.SetActive(active);
        if (pauseTxt != null) pauseTxt.gameObject.SetActive(active);

        // ボタンはポーズ時のみ表示
        if (quitButton != null) quitButton.gameObject.SetActive(active);
        if (optionButton != null) optionButton.gameObject.SetActive(active);

        // カーソル表示切替
        Cursor.lockState = active ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = active;
    }

    // 共通SE再生
    private void PlaySE(AudioClip clip)
    {
        if (audioSource != null && clip != null)
            audioSource.PlayOneShot(clip);
    }

    // Quitボタン
    public void QuitGame()
    {
        PlaySE(quitSE);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    // Optionボタン
    public void OpenOption()
    {
        PlaySE(optionSE);
        Debug.Log("Option画面を開く処理をここに追加");
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
