using UnityEngine;

public class GameEnd : MonoBehaviour
{
    private bool isPaused = false;

    void Update()
    {
        // Shift�L�[���������u�ԂɃ|�[�Y�؂�ւ�
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            isPaused = !isPaused; 
            Debug.Log("Pause���: " + isPaused);
        }

        // �|�[�Y����Esc����������I��
        if (isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; // unity�I���
#else
            Application.Quit(); // �r���h�I���
#endif
        }
    }
}