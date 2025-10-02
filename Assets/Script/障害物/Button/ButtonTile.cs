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

    public bool buttonOK = false;

    void Start()
    {
        for (int i = 0; i < runObject.Count; i++)
        {
            runObject[i].SetActive (false);
        }
    }

    private void ButtonOn()
    {
        Vector3 buttonPosition = transform.position;
        buttonPosition.y -= minusY;
        sound.Play();
        transform.position = buttonPosition;
        for (int i = 0; i < runObject.Count; i++)
        {
            runObject[i].SetActive(true);
        }
    }

    public void ButtonOff()
    {
        buttonOK = false;
        Vector3 buttonPosition = transform.position;
        buttonPosition.y += minusY;
        sound.Play();
        transform.position = buttonPosition;
        for (int i = 0; i < runObject.Count; i++)
        {
            runObject[i].SetActive(false);
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
