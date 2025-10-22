using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [Header("プレイヤーオブジェクト")]
    public GameObject Player;
    [Header("チェックポイント設定")]
    public List<GameObject> checkPoints = new List<GameObject>();
    public List<string> listTag = new List<string>();

    public bool[] ListON;
    public Vector3 playerPosition;

    void Start()
    {
        ListON = new bool[checkPoints.Count]; 
        for (int i = 0; i < checkPoints.Count; i++)
        {
            ListON[i] = false;
        }
        if (checkPoints.Count == 0 || checkPoints.Count != listTag.Count)
        {
            Debug.LogWarning("チェックポイントのプレハブからCheckPointを確認してください");
            return;
        }

        playerPosition = checkPoints[0].transform.position;
        for (int i = 0; i < checkPoints.Count; i++)
        {
            checkPoints[i].tag = listTag[i];
        }
    }

    void Update()
    {
        if(ShareVariable.Share.replay)
        {
            Player.transform.position = playerPosition;
            ShareVariable.Share.replay = false;
        }
    }

    public void TagCheck(string tag, bool needSound)
    {
        for (int i = 0; i < listTag.Count; i++)
        {
            if (tag == listTag[i])
            {
                playerPosition = checkPoints[i].transform.position;
                ListON[i] = true;
                GameObject obj = GameObject.FindWithTag(tag);
                if (obj == null)
                {
                    Debug.LogWarning($"タグ '{tag}' のオブジェクトが見つかりません");
                    return;
                }

                if (obj.TryGetComponent<Runestone_Controller>(out var rune))
                {
                    rune.ToggleRuneStone(true, needSound);
                }
                else
                {
                    Debug.LogWarning("Runestone_Controller が見つかりません");
                }

                return;
            }
        }
    }

    public void StartTagCheck(int num)
    {
        TagCheck(listTag[num], false);
    }

    public Vector3 ReturnCheckPoint()
    {
        return playerPosition;
    }
}