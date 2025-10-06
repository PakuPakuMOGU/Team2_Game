using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoTitle : MonoBehaviour
{
    [System.Serializable]
    public class FadeClass
    {
        public bool yes = true;
        public FadeInOut fadeScript;
    }
    [Header("フェードアウトする？")]
    [SerializeField] private FadeClass fade;

    public void FadeStart()
    {
        if (ShareVariable.Share.clear)
        { 
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

    void ReturnMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
