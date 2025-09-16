using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    public Fade fadeScript;
    public GameObject camera;
    public GameObject FadeCube;

    void Start()
    {
        FadeCube.SetActive(false);
        fadeScript = FadeCube.GetComponent<Fade>();
        if (fadeScript == null)
        {
            Debug.LogWarning("FadeCube に Fade スクリプトがアタッチされていません");
        }
    }
    public Action OnFadeComplete;

    public void StartFade()
    {
        FadeCube.SetActive(true);
        FadeCube.transform.position = camera.transform.position + camera.transform.forward * 0.5f;
        FadeCube.transform.rotation = camera.transform.rotation;
        StartCoroutine(WaitUntilFadeComplete());
    }

    private IEnumerator WaitUntilFadeComplete()
    {
        yield return null;
        fadeScript = FadeCube.GetComponent<Fade>();

        while (fadeScript.colorNow() != 1)
        {
            FadeCube.transform.position = camera.transform.position + camera.transform.forward * 0.5f;
            FadeCube.transform.rotation = camera.transform.rotation;
            yield return null;
        }

        OnFadeComplete?.Invoke(); // Goalに通知.
    }
}