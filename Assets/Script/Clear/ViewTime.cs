using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewTime : MonoBehaviour
{
    [Header("時間表示")]
    public GameObject timeText;

    void Start()
    {
        timeText.transform.position = new Vector3(1300,550,0);
        Cursor.lockState = CursorLockMode.None;     // マウスカーソルの中央固定解除.
        Cursor.visible = true;                      // マウスカーソル表示.
    }
}
