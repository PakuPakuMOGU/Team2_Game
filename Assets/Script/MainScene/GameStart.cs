using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    [System.Serializable]
    public class FadeClass
    {
        public bool yes = true;
        public FadeInOut fadeScript;
    }
    [Header("フェードアウトする？")]
    [SerializeField] private FadeClass fade;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;     // マウスカーソルの中央固定解除.
        Cursor.visible = true;                      // マウスカーソル表示.
    }

    // ボタンが押されたとき.
    public void OnClick()
    {
        if (!fade.yes)
        {
            ReturnGameScene();         // フェードしない場合すぐに移行.
        }
        else
        {
            fade.fadeScript.OnFadeComplete = ReturnGameScene;
            fade.fadeScript.StartFade();
        }
    }
    private void ReturnGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
}