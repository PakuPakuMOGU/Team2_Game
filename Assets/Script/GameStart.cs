using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStart : MonoBehaviour
{
    // ƒ{ƒ^ƒ“‚ª‰Ÿ‚³‚ê‚½‚Æ‚«.
    public void OnClick()
    {
        Debug.Log("‰Ÿ‚³‚ê‚½!");
        SceneManager.LoadScene("GameScene");
    }
}
