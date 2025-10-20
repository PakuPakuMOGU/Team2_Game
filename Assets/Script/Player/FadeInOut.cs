using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    private Fade fadeScript;
    public GameObject FadePanel;

    void Start()
    {
        FadePanel.SetActive(false);
        fadeScript = FadePanel.GetComponent<Fade>();
        if (fadeScript == null)
        {
            Debug.LogWarning("FadeCube に Fade スクリプトがアタッチされていません");
        }
    }
    public Action OnFadeComplete;

    public void StartFade()
    {
        FadePanel.SetActive(true);
        StartCoroutine(WaitUntilFadeComplete());
    }

    private IEnumerator WaitUntilFadeComplete()
    {       
        fadeScript = FadePanel.GetComponent<Fade>();
        yield return null;

        while (fadeScript.GetCurrentAlpha() != 1)
        {
            yield return null;
        }

        OnFadeComplete?.Invoke();
    }
}