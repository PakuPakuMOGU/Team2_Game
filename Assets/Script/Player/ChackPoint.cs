using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;

public class ChackPoint : MonoBehaviour
{
    [Header("チェックポイント設定")]
    public List<Vector3> listPosition = new List<Vector3>();
    public List<Vector3> listSize     = new List<Vector3>();
    public List<string>  listTag      = new List<string>();
    public GameObject ChackPointPrefab;

    private int listCount;
    private int chackOK = 0; 

    void Start()
    {
        listCount = listPosition.Count;
        for (int i = 0; i < listCount; i++)
        {
            Vector3 pos = listPosition[i];
            Vector3 siz = new Vector3(1.0f, 1.0f, 1.0f);
            if (listSize[i] != null) siz = listSize[i];                 
            Instantiate(ChackPointPrefab, pos, Quaternion.identity);
            ChackPointPrefab.transform.localScale = siz;
            ChackPointPrefab.gameObject.tag = listTag[i];
        }
    }

    void Update()
    {
        
    }
}
