using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [Header("ゴール座標範囲")]
    public Vector3 boxPosition = new Vector3(0, 0, 0);
    public float r = 5;

    [Header("メインカメラ")]
    public Camera camera;

    [Header("フェードキューブ")]
    public GameObject FadeCube;
    private Fade fadescript;

    private int colorNum = 0;
    private bool clearTag = false;
    private bool returnTag = false;

    void Start()
    {
        FadeCube.SetActive(false);
        Camera.main.nearClipPlane = 0.01f;
        fadescript = FadeCube.GetComponent<Fade>();
        this.transform.localScale = new Vector3(r, r, r);
        this.transform.position = boxPosition;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && clearTag)
        {
            FadeCube.transform.position = camera.transform.position + camera.transform.forward * 0.5f;
            FadeCube.transform.rotation = camera.transform.rotation;
            FadeCube.SetActive(true);
            returnTag = true;
        }
        if (returnTag)
        {
            colorNum = fadescript.colorNow();
            if (colorNum == 1)
            {
                SceneManager.LoadScene("MainScene");
            }
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("Clear!!!");
            clearTag = true;
            // ここでゴール用の関数を呼び出す.
        }
    }
}
