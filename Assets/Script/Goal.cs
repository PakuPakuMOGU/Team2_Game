using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    [Header("�S�[�����W�͈�")]
    public Vector3 boxPosition = new Vector3(0, 0, 0);
    public float r = 5;

    void Start()
    {
        this.transform.localScale = new Vector3(r, r, r);
        this.transform.position = boxPosition;
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
