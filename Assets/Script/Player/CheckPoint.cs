using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class CheckPoint : MonoBehaviour
{
    [Header("チェックポイント設定")]
    public List<Vector3> listPosition = new List<Vector3>();
    public List<Vector3> listSize     = new List<Vector3>();
    public List<string>  listTag      = new List<string>();
    public GameObject CheckPointPrefab;

    private Vector3 playerPosition;

    void Start()
    {
        int listCount = listPosition.Count;
        if (listCount > 0) playerPosition = listPosition[0];
        for (int i = 0; i < listCount; i++)
        {
            Vector3 pos = listPosition[i];
            Vector3 siz = new Vector3(1.0f, 1.0f, 1.0f);
            if (listSize[i] != null) siz = listSize[i];                 
            Instantiate(CheckPointPrefab, pos, Quaternion.identity);
            CheckPointPrefab.transform.localScale = siz;
            CheckPointPrefab.gameObject.tag = listTag[i];
        }
    }

    void Update()
    {
        // Debug.Log(playerPosition);   // チェックポイント変更確認用.
    }

    public void TagCheck(string tag)
    {
        int listCount = listTag.Count;
        for (int i = 0; i < listCount; i++)
        {
            if (tag == listTag[i])
            {
                playerPosition = listPosition[i];
            }
        }
    }
}
