using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewTime : MonoBehaviour
{
    [Header("ŽžŠÔ•\Ž¦")]
    public GameObject timeText;

    void Start()
    {
        timeText.transform.position = new Vector3(1300,450,0);
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        
    }
}
