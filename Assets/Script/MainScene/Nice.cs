using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Nice : MonoBehaviour
{
    [System.Serializable]
    public class FadeClass
    {
        public bool yes = true;
        public FadeInOut fadeScript;
    }
    [Header("フェードアウトする？")]
    [SerializeField] private FadeClass fade;

    void OnTriggerEnter(Collider collider)
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
        SceneManager.LoadScene("ojiScene");
    }
}
