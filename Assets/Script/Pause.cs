using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Pause : MonoBehaviour
{
    public Image pauseBack;          // �w�i�摜
    public TextMeshProUGUI pauseTxt; // �e�L�X�g (TMP���g���ꍇ)

    private bool isPaused = false;

    void Start()
    {
        // �ŏ��͔�\��
        if (pauseBack != null) pauseBack.gameObject.SetActive(false);
        if (pauseTxt != null) pauseTxt.gameObject.SetActive(false);
    }

    void Update()
    {
        // Shift�L�[�ňꎞ��~��؂�ւ�
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0f : 1f;

            if (pauseBack != null) pauseBack.gameObject.SetActive(isPaused);
            if (pauseTxt != null) pauseTxt.gameObject.SetActive(isPaused);

            Debug.Log("Pause���: " + isPaused);
        }

        // �|�[�Y���� Esc �ŏI��
        if (isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}
