using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameFinish : MonoBehaviour
{
    // ƒ{ƒ^ƒ“‚ª‰Ÿ‚³‚ê‚½‚Æ‚«.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            OnClick();
    }
    public void OnClick()
    {
        Debug.Log("‰Ÿ‚³‚ê‚½!");/*
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        */
    }
}
