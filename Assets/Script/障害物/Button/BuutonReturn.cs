using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuutonReturn : MonoBehaviour
{
    [Header("ButtonTileスクリプト")]
    public ButtonTile buttonTile;

    [Header("ボタンを戻す秒数")]
    public float num = 1.0f;

    private int timeCount = 0;

    void Start()
    {
        num *= 60;
    }

    void Update()
    {
        if (buttonTile.buttonOK)
        {
            if (timeCount > num)
            {
                buttonTile.ButtonOff();
                timeCount = 0;
            }
            timeCount++;
        }
    }
}
