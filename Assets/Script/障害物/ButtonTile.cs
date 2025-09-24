using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonTile : MonoBehaviour
{
    [Header("É{É^ÉìÇÃâüÇµçûÇ›ãÔçá")]
    public float minusY = 0.1f;
    private bool buttonOK = false;

    private void ButtonOn()
    {
        Vector3 buttonPosition = transform.position;
        buttonPosition.y -= minusY;
        transform.position = buttonPosition;
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
