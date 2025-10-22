using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewTime : MonoBehaviour
{
    [Header("時間表示")]
    public RectTransform timeText;

    void Start()
    {
        // アンカーを中央に設定.
        timeText.anchorMin = new Vector2(0.5f, 0.5f);
        timeText.anchorMax = new Vector2(0.5f, 0.5f);
        timeText.pivot = new Vector2(0.5f, 0.5f);

        // 位置を中央に設定.
        timeText.anchoredPosition = new Vector2(80f,0.5f);

        Cursor.lockState = CursorLockMode.None;     // マウスカーソルの中央固定解除.
        Cursor.visible = true;                      // マウスカーソル表示.
    }
}