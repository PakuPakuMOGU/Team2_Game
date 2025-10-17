using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClearButton : MonoBehaviour
{
    [System.Serializable]
    public class FadeClass
    {
        public bool yes = true;
        public FadeInOut fadeScript;
    }
    [Header("フェードアウトする？")]
    [SerializeField] private FadeClass fade;

    public AudioSource ReturnMainSound;
    public AudioSource ReturnGameSound;

    public void OnClick_Gotitle()
    {
        ReturnMainSound?.Play();
        if (!fade.yes)
        {
            ReturnMainScene();         // フェードしない場合すぐに移行.
        }
        else
        {
            fade.fadeScript.OnFadeComplete = ReturnMainScene;
            fade.fadeScript.StartFade();
        }
    }

    public void OnClick_OneMore()
    {
        ReturnGameSound?.Play();
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

    private void ReturnMainScene()
    {
        SceneManager.LoadScene("MainScene"); 
    }

    private void ReturnGameScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
