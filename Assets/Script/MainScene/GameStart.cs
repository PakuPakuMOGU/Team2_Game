using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;     // マウスカーソルの中央固定解除.
        Cursor.visible = true;                      // マウスカーソル表示.
    }
    // ボタンが押されたとき.
    public void OnClick()
    {
        SceneManager.LoadScene("GameScene");
    }
}