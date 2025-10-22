using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinish : MonoBehaviour
{
    [System.Serializable]
    public class FadeClass
    {
        public bool yes = true;
        public FadeInOut fadeScript;
    }
    [Header("フェードアウトする？")]
    [SerializeField] private FadeClass fade;

    // ボタンが押されたとき.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            OnClick();
    }
    public void OnClick()
    {
        if (!fade.yes)
        {
            FinishGame();         // フェードしない場合すぐに移行.
        }
        else
        {
            fade.fadeScript.OnFadeComplete = FinishGame;
            fade.fadeScript.StartFade();
        }
        Debug.Log("押された!");
    
    }

    private void FinishGame()
    {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif   
    }
}
