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
    public Date data;

    [Header("フェードスクリプト")]
    public FadeInOut fadeScript;

    [Header("Menu画面")]
    public GameObject Menu;

    [Header("効果音設定")]
    public AudioSource SE;  

    void Start()
    {
        SetPauseUI(false);
        ShareVariable.Share.stop = false;
        Time.timeScale = 1f;
    }

    void Update()
    {
        // 「T」キーでポーズON/OFF
        if (Input.GetKeyDown(KeyCode.T)) Close();
    }

    private void SetPauseUI(bool active)
    {
        Menu?.gameObject.SetActive(active);

        Cursor.lockState = active ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = active;
    }

    public void QuitGame()
    {
        data.Save();
        fadeScript.OnFadeComplete = Exit;
        fadeScript.StartFade();
    }

    public void Exit()
    {
        SE.Play();
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void RePlayGame()
    {
        data.Reset();
        fadeScript.OnFadeComplete = ReturnGameScene;
        fadeScript.StartFade();
    }

    private void ReturnGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void Close()
    {
        ShareVariable.Share.stop = !ShareVariable.Share.stop;
        SetPauseUI(ShareVariable.Share.stop);
        Time.timeScale = ShareVariable.Share.stop ? 0f : 1f;

        SE.Play();
    }

    public void OpenOption()
    {
        //オプション画面を開く処理があれば追加.

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
