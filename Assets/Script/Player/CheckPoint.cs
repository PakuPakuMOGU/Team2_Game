using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [Header("チェックポイント設定")]
    public List<GameObject> checkPoint = new List<GameObject>();
    public List<string> listTag = new List<string>();

    private Vector3 playerPosition;

    void Start()
    {
        // 初期化.
        int listCount = checkPoint.Count;
        if (listCount > 0)
        {
            playerPosition = checkPoint[0].transform.position;
        }

        for (int i = 0; i < listCount; i++)
        {
            checkPoint[i].tag = listTag[i];
        }
    }

    public void TagCheck(string tag)
    {
        int listCount = listTag.Count;
        for (int i = 0; i < listCount; i++)
        {
            if (tag == listTag[i])
            {
                playerPosition = checkPoint[i].transform.position;
                GameObject obj = GameObject.FindWithTag(tag);
                if (obj != null)
                {
                    Runestone_Controller rune = obj.GetComponent<Runestone_Controller>();
                    if (rune != null)
                    {
                        rune.ToggleRuneStone(true);
                    }
                    else
                    {
                        Debug.Log("Runestone_Controllerが見つかりません");
                    }
                }
                else
                {
                    Debug.Log("タグ：" + tag + " が見つかりません");
                }
            }
        }
    }

    // プレイヤーのチェックポイント地点を返す関数.
    public Vector3 ReturnCheckPoint()
    {
        return playerPosition;
    }
}
