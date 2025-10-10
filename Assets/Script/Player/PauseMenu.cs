using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseMenu : MonoBehaviour
{
    [Header("UI設定")]
    public Image pauseBack;                 // 背景パネル
    public TextMeshProUGUI pauseTxt;        // ポーズ用テキスト
    public Button quitButton;               // Quit ボタン
    public Button optionButton;             // Option ボタン

    [Header("効果音設定")]
    public AudioSource audioSource;         // 効果音再生用
    public AudioClip quitSE;                // Quit ボタン用SE
    public AudioClip optionSE;              // Option ボタン用SE
    public AudioClip resumeSE;              // 再開用SE
    public AudioClip pauseSE;               // ポーズON用SE

    private bool isPaused = false;

    void Start()
    {
        SetPauseUI(false);

        if (quitButton != null)
            quitButton.onClick.AddListener(QuitGame);
        if (optionButton != null)
            optionButton.onClick.AddListener(OpenOption);
    }

    void Update()
    {
        // 「T」キーでポーズON/OFF
        if (Input.GetKeyDown(KeyCode.T))
        {
            isPaused = !isPaused;
            SetPauseUI(isPaused);
            Time.timeScale = isPaused ? 0f : 1f;

            if (isPaused) PlaySE(pauseSE);
            else PlaySE(resumeSE);
        }

        // ポーズ中に「Esc」で終了
        if (isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    private void SetPauseUI(bool active)
    {
        if (pauseBack != null)
            pauseBack.gameObject.SetActive(active);
        if (pauseTxt != null)
            pauseTxt.gameObject.SetActive(active);
        if (quitButton != null)
            quitButton.gameObject.SetActive(active);
        if (optionButton != null)
            optionButton.gameObject.SetActive(active);

        Cursor.lockState = active ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = active;
    }

    private void PlaySE(AudioClip clip)
    {
        if (audioSource != null && clip != null)
            audioSource.PlayOneShot(clip);
    }

    public void QuitGame()
    {
        PlaySE(quitSE);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void OpenOption()
    {
        PlaySE(optionSE);
        Debug.Log("オプション画面を開く処理をここに追加してください。");

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
