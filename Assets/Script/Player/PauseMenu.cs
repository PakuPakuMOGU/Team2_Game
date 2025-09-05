using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Image pauseBack;
    public Text pauseTxt;
    public GameObject pausePanel;

    private bool isPaused = false;

    void Start()
    {
        SetAlpha(pauseBack, 0f);
        SetAlpha(pauseTxt, 0f);
        pausePanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            if (isPaused) ResumeGame();
            else ShowPause();
        }
    }

    public void ShowPause()
    {
        pausePanel.SetActive(true);
        SetAlpha(pauseBack, 1f);
        SetAlpha(pauseTxt, 1f);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        SetAlpha(pauseBack, 0f);
        SetAlpha(pauseTxt, 0f);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("ÉQÅ[ÉÄèIóπ");
    }

    public void LoadTitle()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("TitleScene");
    }

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
