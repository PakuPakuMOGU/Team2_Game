using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [Header("最初の透明度は？")]
    [SerializeField] private int firstAlpha = 0;

    [Header("終わりの透明度は？")]
    [SerializeField] private int lastAlpha = 255;

    [Header("所要時間（秒）")]
    [SerializeField] private float fadeDuration = 1f;

    [Header("Mesh or Image")]
    [SerializeField] private bool useMesh = true;

    private MeshRenderer mesh;
    private Image image;
    private Coroutine fadeCoroutine;
    private float end;

    void Start()
    {
        Application.targetFrameRate = 60;

        if (useMesh)
{
    mesh = GetComponent<MeshRenderer>();
    if (mesh == null)
    {
        Debug.LogError("MeshRenderer が見つかりません");
        return;
    }

    Color initColor = mesh.material.color;
    initColor.a = Mathf.Clamp01((float)firstAlpha / 255f);
    mesh.material.color = initColor;
}
        else
        {
            image = GetComponent<Image>();
            if (image == null)
            {
                Debug.LogError("Image コンポーネントが見つかりません");
                return;
            }

            Color initColor = image.color;
            initColor.a = Mathf.Clamp01((float)firstAlpha / 255f);
            image.color = initColor;
        }

        StartFade();
    }

    void StartFade()
    {
        Debug.Log("Point");
        if (fadeCoroutine != null) StopCoroutine(fadeCoroutine);
        fadeCoroutine = StartCoroutine(FadeAlpha());
    }

    IEnumerator FadeAlpha()
    {
        float start = Mathf.Clamp01((float)firstAlpha / 255f);
        end = Mathf.Clamp01((float)lastAlpha / 255f);
        float elapsed = 0f;

        while (elapsed < fadeDuration)
        {
            float t = elapsed / fadeDuration;
            float currentAlpha = Mathf.Lerp(start, end, t);

            if (useMesh)
            {
                Color color = mesh.material.color;
                color.a = currentAlpha;
                mesh.material.color = color;
            }
            else
            {

                Debug.Log($"currentAlpha = {currentAlpha}");
                Color color = image.color;
                color.a = currentAlpha;
                image.color = color;
            }

            Debug.Log($"currentAlpha = {currentAlpha}");
            elapsed += Time.deltaTime;
            Debug.Log($"elapsed = {elapsed}");
            yield return null;
        }

        // 最終値を設定
        if (useMesh)
        {
            Color color = mesh.material.color;
            color.a = end;
            mesh.material.color = color;
        }
        else
        {
            Color color = image.color;
            color.a = end;
            image.color = color;
        }
    }

    public float GetCurrentAlpha()
    {
        if (useMesh && mesh != null)
        {
            if (Mathf.Approximately(mesh.material.color.a, end)) return 1;
            else return 0;
        }
        else if (!useMesh && image != null)
        {
            if (Mathf.Approximately(image.color.a, end)) return 1;
            else return 0;
        }

        Debug.LogWarning("対象のコンポーネントが見つかりません");
        return -1f;
    }
}