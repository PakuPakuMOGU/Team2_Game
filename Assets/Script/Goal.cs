using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [Header("クリアポイント設定")]
    public GameObject goalPoint;

    [System.Serializable]
    public class FadeClass
    {
        public bool yes = true;
        public FadeInOut fadeScript;
    }
    [Header("フェードアウトする？")]
    [SerializeField] private FadeClass fade;
    private bool fadeStarted = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (ShareVariable.Share.clear && !fadeStarted)
        {
            fadeStarted = true;

            if (!fade.yes)
            {
                ReturnMainScene();           // フェードしない場合すぐに移行.
            }
            else
            {
                fade.fadeScript.OnFadeComplete = ReturnMainScene;
                fade.fadeScript.StartFade();
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            Debug.Log("Clear!!!");
            ShareVariable.Share.clear = true;   // 全体共有の変数を変更.
        }
    }

    void ReturnMainScene()
    { 
        SceneManager.LoadScene("MainScene");
    }
}