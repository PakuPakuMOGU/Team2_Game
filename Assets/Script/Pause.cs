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
        SetAlpha(pauseBack, 0f);
        SetAlpha(pauseTxt, 0f);
    }

    void Update()
    {
        // Shift�L�[�ňꎞ��~��؂�ւ�
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            isPaused = !isPaused;
            Debug.Log("Pause���: " + isPaused);

            if (isPaused)
            {
                Time.timeScale = 0f; // ��~
                SetAlpha(pauseBack, 1f);
                SetAlpha(pauseTxt, 1f);
            }
            else
            {
                Time.timeScale = 1f; // �ĊJ
                SetAlpha(pauseBack, 0f);
                SetAlpha(pauseTxt, 0f);
            }
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

    // �����x�𑦍��ɕύX
    private void SetAlpha(Graphic g, float alpha)
    {
        if (g != null)
        {
            Color c = g.color;
            c.a = alpha;
            g.color = c;
        }
    }
}