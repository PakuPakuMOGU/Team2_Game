using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positionDate : MonoBehaviour
{
    [System.Serializable]
    public class Position
    {
        public bool yes = false;
        public Vector3 position;
    }
    [Header("スクリプトで座標を設定する？")]
    public Position Posi;

    private Vector3 v3BasePosition;

    void Start()
    {
        v3BasePosition = Posi.yes ? Posi.position : transform.position;     // 初期化.
    }
    
    // 座標を変更する.
    public void BasePositionChange(float x, float y, float z)
    {
        v3BasePosition = new Vector3(x, y, z);
        transform.position = v3BasePosition;
    }

    public Vector3 ReturnPosition(string str)
    {
        switch (str)
        {
            case "Base": return v3BasePosition;
            case "Now":  return transform.position;
        }
        Debug.Log("ポジション呼び出しミスってます");
        return new Vector3(0, 0, 0);
    }

    // 現在の座標を返す.
    public float NowPositionOne(char xyz)
    {
        switch (xyz)
        {
            case 'x': return transform.position.x;
            case 'y': return transform.position.y;
            case 'z': return transform.position.z;
        }
        return - 1.0f;
    }

    // 現在の座標を変える.
    public void NowPositionChange(char xyz, float num)
    {
        Vector3 v3NowPosition = transform.position;
        switch (xyz)
        {
            case 'x': v3NowPosition.x = num; transform.position = v3NowPosition; break;
            case 'y': v3NowPosition.y = num; transform.position = v3NowPosition; break;
            case 'z': v3NowPosition.z = num; transform.position = v3NowPosition; break;
        }     
    }
}