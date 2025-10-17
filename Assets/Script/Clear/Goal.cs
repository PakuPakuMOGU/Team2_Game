using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [Header("クリアポイント設定")]
    public GameObject goalPoint;

    [Header("クリアディスプレイ表示")]
    public GameObject clearDisplay;

    [Header("クリアサウンド")]
    public AudioSource sound;

    void Start()
    {
        clearDisplay.SetActive(false);
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            sound.Play();
            clearDisplay.SetActive(true);
            ShareVariable.Share.clear = true;   // 全体共有の変数を変更.
        }
    }
}