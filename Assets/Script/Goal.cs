using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    [Header("�S�[�����W�͈�")]
    public Vector3 boxPosition = new Vector3(0, 0, 0);
    public float r = 5;
    private bool clearTag = false;

    void Start()
    {
        this.transform.localScale = new Vector3(r, r, r);
        this.transform.position = boxPosition;
    }

    void UpDate()
    {
        if (Input.GetMouseButtonDown(0) && clearTag)
        {
            SceneManager.LoadScene("MainScene");
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("Clear!!!");
            
            // �����ŃS�[���p�̊֐����Ăяo��.
        }
    }
}
