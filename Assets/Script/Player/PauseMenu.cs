using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseMenu : MonoBehaviour
{
    [Header("Dateスクリプト")]
    public Date date;

    [Header("フェードスクリプト")]
    public FadeInOut fadeScript;


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

    void Start()
    {
        SetPauseUI(false);

        quitButton?.onClick.AddListener(QuitGame);
        optionButton?.onClick.AddListener(OpenOption);
    }

    void Update()
    {
        // 「T」キーでポーズON/OFF
        if (Input.GetKeyDown(KeyCode.T))
        {
            ShareVariable.Share.stop = !ShareVariable.Share.stop;
            SetPauseUI(ShareVariable.Share.stop);
            Time.timeScale = ShareVariable.Share.stop ? 0f : 1f;

            if (ShareVariable.Share.stop) PlaySE(pauseSE);
            else PlaySE(resumeSE);
        }

        // ポーズ中に「Esc」で終了
        if (ShareVariable.Share.stop && Input.GetKeyDown(KeyCode.Escape))
        {
            QuitGame();
        }
    }

    private void SetPauseUI(bool active)
    {
        pauseBack?.gameObject.SetActive(active);
        pauseTxt?.gameObject.SetActive(active);
        quitButton?.gameObject.SetActive(active);
        optionButton?.gameObject.SetActive(active);

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
        date.Save();
        fadeScript.OnFadeComplete = Exit;
        fadeScript.StartFade();
    }

    public void Exit()
    {
        PlaySE(quitSE);
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
