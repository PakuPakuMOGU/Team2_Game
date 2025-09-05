using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Image pauseBack;             // �w�i�p�l��
    public TextMeshProUGUI pauseTxt;    // �|�[�Y�p�e�L�X�g
    public Button quitButton;           // Quit �{�^��
    public Button optionButton;         // Option �{�^��

    private bool isPaused = false;

    void Start()
    {
        // ������Ԃ͓�����
        SetPauseUI(false);
    }

    void Update()
    {
        // Shift �L�[�Ń|�[�Y�ؑ�
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            isPaused = !isPaused;
            SetPauseUI(isPaused);
            Time.timeScale = isPaused ? 0f : 1f;  // �|�[�Y���̓Q�[����~
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

    private void SetPauseUI(bool active)
    {
        // �w�i�͔�����
        if (pauseBack != null)
            SetAlpha(pauseBack, active ? 0.5f : 0f);

        // �e�L�X�g�͊��S�s����
        if (pauseTxt != null)
            SetAlpha(pauseTxt, active ? 1f : 0f);

        // �{�^���������x�ŊǗ�
        if (quitButton != null)
            SetButtonAlpha(quitButton, active ? 1f : 0f);
        if (optionButton != null)
            SetButtonAlpha(optionButton, active ? 1f : 0f);
    }

    // Graphic �̓����x��ύX
    private void SetAlpha(Graphic g, float alpha)
    {
        if (g != null)
        {
            Color c = g.color;
            c.a = alpha;
            g.color = c;
        }
    }

    // Button ���� Image �� TextMeshProUGUI ���܂Ƃ߂ē����x�ύX
    private void SetButtonAlpha(Button button, float alpha)
    {
        if (button == null) return;

        // �{�^���w�i Image
        Image img = button.GetComponent<Image>();
        if (img != null)
            SetAlpha(img, alpha);

        // �{�^���̃e�L�X�g
        TextMeshProUGUI txt = button.GetComponentInChildren<TextMeshProUGUI>();
        if (txt != null)
            SetAlpha(txt, alpha);

        // �{�^�����̂� interactable �� alpha �ɉ����Đؑցi�C�Ӂj
        button.interactable = alpha > 0f;
    }

    // �{�^���p���\�b�h
    public void QuitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void OpenOption()
    {
        Debug.Log("Option��ʂ��J�������������ɒǉ�");
    }
}
