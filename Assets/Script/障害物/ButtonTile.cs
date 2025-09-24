using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTile : MonoBehaviour
{
    [Header("ボタンの押し込み具合")]
    public float minusY = 0.1f;

    [Header("動かしたいスクリプトが入ってるゲームオブジェクト")]
    public List<GameObject> runObject = new List<GameObject> ();

    private bool buttonOK = false;

    void Start()
    {
        int listCount = runObject.Count;
        for (int i = 0; i < listCount; i++)
        {
            runObject[i].SetActive (false);
        }
    }

    private void ButtonOn()
    {
        Vector3 buttonPosition = transform.position;
        buttonPosition.y -= minusY;
        transform.position = buttonPosition;
        int listCount = runObject.Count;
        for (int i = 0; i < listCount; i++)
        {
            runObject[i].SetActive(true);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !buttonOK)
        {
            buttonOK = true;
            ButtonOn();
        }
    }
}
