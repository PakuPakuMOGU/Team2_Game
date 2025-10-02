using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTile : MonoBehaviour
{
    [Header("ボタンの押し込み具合")]
    public float minusY = 0.1f;

    [Header("動かしたいスクリプトが入ってるゲームオブジェクト")]
    public List<GameObject> runObject = new List<GameObject> ();

    public AudioSource sound;

    public bool buttonOK;

    void Start()
    {
        buttonOK = false;
        ButtonActive();
    }

    private void ButtonOn()
    {
        buttonOK = true;
        ButtonSet();
    }

    public void ButtonOff()
    {
        buttonOK = false;
        ButtonSet();   
    }

    private void ButtonSet()
    {
        Vector3 buttonPosition = transform.position;
        if(buttonOK) buttonPosition.y -= minusY;
        else         buttonPosition.y += minusY;
        sound.Play();
        transform.position = buttonPosition;
        ButtonActive();
    }

    private void ButtonActive()
    {
        for (int i = 0; i < runObject.Count; i++)
        {
            runObject[i].SetActive(buttonOK);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !buttonOK)
        {
            ButtonOn();
        }
    }
}
