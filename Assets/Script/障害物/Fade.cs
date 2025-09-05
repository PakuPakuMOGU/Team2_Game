using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    [Header("最初の透明度は？")]
    [SerializeField]
    private int first_A = 0;

    [Header("終わりの透明度は？")]
    [SerializeField]
    private int last_A = 255;

    [Header("所要時間")]
    [SerializeField]
    private int colorTime = 1;

    MeshRenderer mesh;
    private int countdayo;
    Color32 currentColor;

    void Start()
    {
        Application.targetFrameRate = 60;
        mesh = GetComponent<MeshRenderer>();
        currentColor = mesh.material.color;
        mesh.material.color = new Color32(currentColor.r, currentColor.g, currentColor.b, (byte)first_A);

        int value_A = Mathf.Abs(last_A - first_A);
        countdayo = value_A / colorTime;
    }

    void Update()
    {
        if (countdayo >= 0)
        {
            countdayo--;
            if (first_A > last_A)
                mesh.material.color -= new Color32(0, 0, 0, (byte)colorTime);
            else
                mesh.material.color += new Color32(0, 0, 0, (byte)colorTime);
        }
        else
        {
            mesh.material.color = new Color32(currentColor.r, currentColor.g, currentColor.b, (byte)last_A);
        }
    }

    public int colorNow()
    {
        return (int)mesh.material.color.a;
    }
}