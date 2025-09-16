using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [Header("クリアポイント設定")]
    public Vector3 boxPosition = new Vector3(0, 0, 0);
    public float r = 5;

    [System.Serializable]
    public class FadeClass
    {
        public bool yes = true;

        [Header("メインカメラ")]
        public Camera camera;

        [Header("フェードオブジェクト")]
        public GameObject FadeCube;
    }
    [Header("フェードアウトする？")]
    [SerializeField] private FadeClass fade;

    private Fade fadeScript;
    private int colorNum = 0;

    void Start()
    {
        if (fade.yes)
        {
            fade.FadeCube.SetActive(false);
            fadeScript = fade.FadeCube.GetComponent<Fade>();
            if (fadeScript == null)
            {
                Debug.LogWarning("FadeCube に Fade スクリプトがアタッチされていません");
            }
        }
        this.transform.localScale = new Vector3(r, r, r);
        this.transform.position = boxPosition;
    }

    void Update()
    {
        if (ShareVariable.Share.clear)
        {
            if (!fade.yes) ReturnMainScene();
            else
            {
                // カメラの位置・向きに合わせてフェードアウト用オブジェクトの位置を調整.
                fade.FadeCube.transform.position = fade.camera.transform.position + fade.camera.transform.forward * 0.5f;
                fade.FadeCube.transform.rotation = fade.camera.transform.rotation;
                fade.FadeCube.SetActive(true);
                colorNum = fadeScript.colorNow();
                if (colorNum == 1)  ReturnMainScene();
                
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
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