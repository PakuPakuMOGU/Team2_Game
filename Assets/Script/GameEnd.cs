using UnityEngine;
using UnityEngine.UI; // Image, Text ���g������

public class Pose : MonoBehaviour
{
    public Image PoseBack;    // �w�i�摜
    public Text Posetxt;      // �e�L�X�g

    private bool isPaused = false;

    void Start()
    {
        // �f�t�H���g�œ����ɂ���
        SetAlpha(PoseBack, 0f);
        SetAlpha(Posetxt, 0f);
    }

    void Update()
    {
        // Shift�L�[�Ń|�[�Y�؂�ւ�
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            isPaused = !isPaused;

            if (isPaused)
            {
                // �\��
                SetAlpha(PoseBack, 1f);
                SetAlpha(Posetxt, 1f);
                Time.timeScale = 0f; // �Q�[����~
            }
            else
            {
                // ��\��
                SetAlpha(PoseBack, 0f);
                SetAlpha(Posetxt, 0f);
                Time.timeScale = 1f; // �Q�[���ĊJ
            }
        }
    }

    // �����x�𑦎��ɕύX����֐�
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
