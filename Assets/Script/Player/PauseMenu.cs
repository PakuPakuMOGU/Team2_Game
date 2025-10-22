using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

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

    [Header("オプションUI")]
    public GameObject optionPanel;          // オプション画面用パネル
    public Slider bgmSlider;                // BGM音量スライダー
    public Slider seSlider;                 // 効果音スライダー
    public Button optionBackButton;         // オプション→戻るボタン

    [Header("Audio設定")]
    public AudioMixer audioMixer;           // AudioMixerを指定
    public AudioSource audioSource;         // 効果音再生用AudioSource
    public AudioClip quitSE;
    public AudioClip optionSE;
    public AudioClip resumeSE;
    public AudioClip pauseSE;

    private bool isPaused = false;

    void Start()
    {
        // ポーズUIを非表示
        SetPauseUI(false);
        // オプションパネル非表示
        if (optionPanel != null)
            optionPanel.SetActive(false);

        // ボタン登録
        if (quitButton != null)
            quitButton.onClick.AddListener(QuitGame);
        if (optionButton != null)
            optionButton.onClick.AddListener(OpenOption);
        if (optionBackButton != null)
            optionBackButton.onClick.AddListener(CloseOption);

        // スライダー初期化
        float bgmVolume = PlayerPrefs.GetFloat("BGMVolume", 0.75f);
        float seVolume = PlayerPrefs.GetFloat("SEVolume", 0.75f);

        bgmSlider.value = bgmVolume;
        seSlider.value = seVolume;

        SetBGMVolume(bgmVolume);
        SetSEVolume(seVolume);

        bgmSlider.onValueChanged.AddListener(SetBGMVolume);
        seSlider.onValueChanged.AddListener(SetSEVolume);
    }

    void Update()
    {
        // 「T」キーでポーズON/OFF
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (optionPanel != null && optionPanel.activeSelf) return; // オプション中はポーズ切替不可

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
        if (optionPanel != null)
            optionPanel.SetActive(true);

        // ポーズUIを隠す
        SetPauseUI(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void CloseOption()
    {
        if (optionPanel != null)
            optionPanel.SetActive(false);
        SetPauseUI(true);
        PlaySE(resumeSE);
    }

    // --- 音量調整関連 ---
    public void SetBGMVolume(float value)
    {
        audioMixer.SetFloat("BGMVolume", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("BGMVolume", value);
    }

    public void SetSEVolume(float value)
    {
        audioMixer.SetFloat("SEVolume", Mathf.Log10(value) * 20);
        PlayerPrefs.SetFloat("SEVolume", value);
    }
}