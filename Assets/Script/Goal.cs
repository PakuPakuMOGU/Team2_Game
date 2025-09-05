using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [Header("�S�[�����W�͈�")]
    public Vector3 boxPosition = new Vector3(0, 0, 0);
    public float r = 5;

    [System.Serializable]
    public class FadeClass
    {
        public bool yes = true;

        [Header("���C���J����")]
        public Camera camera;

        [Header("�t�F�[�h�L���[�u")]
        public GameObject FadeCube;
    }
    [Header("フェードアウトする？")]
    [SerializeField] private FadeClass fade;

    private Fade fadeScript;
    private bool returnTag = false;

    private int colorNum = 0;
    private bool clearTag = false;

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
        if (Input.GetMouseButtonDown(0) && clearTag)
        {
            if (!fade.yes) ReturnMainScene();
            else
            {
                fade.FadeCube.transform.position = fade.camera.transform.position + fade.camera.transform.forward * 0.5f;
                fade.FadeCube.transform.rotation = fade.camera.transform.rotation;
                fade.FadeCube.SetActive(true);
                returnTag = true;
            }
        }
        if (returnTag)
        {
            colorNum = fadeScript.colorNow();
            if (colorNum == 1)
            {
                ReturnMainScene();
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("Clear!!!");
            clearTag = true;
            // �����ŃS�[���p�̊֐����Ăяo��.
        }
    }

    void ReturnMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}