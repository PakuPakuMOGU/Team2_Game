using UnityEngine;

public class GameEnd : MonoBehaviour
{
    private bool isPaused = false;

    void Update()
    {
        // Shiftキーを押した瞬間にポーズ切り替え
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            isPaused = !isPaused; 
            Debug.Log("Pause状態: " + isPaused);
        }

        // ポーズ中にEscを押したら終了
        if (isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // unity終わり
#else
            Application.Quit(); // ビルド終わり
#endif
        }
    }
}