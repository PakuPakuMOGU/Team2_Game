using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{
    [Header("“§–¾‚É‚È‚éŽžŠÔ")]
    [SerializeField]
    private int ColorDown = 1;

    MeshRenderer mesh;
    int countdayo;

    void Start()
    {
        Application.targetFrameRate = 60;
        mesh = GetComponent<MeshRenderer>();

        countdayo = 255 / ColorDown;
    }
    void Update()
    {

        if (countdayo > 0)
        {
            countdayo--;
            mesh.material.color -= new Color32(0, 0, 0, (byte)ColorDown);
        }
        else
            mesh.material.color = new Color32(0, 0, 0, 0);
    }
}
