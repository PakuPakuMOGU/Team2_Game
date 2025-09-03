using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positionDate : MonoBehaviour
{
    [Header("初期座標")]
    [SerializeField]
    private Vector3 v3BasePosition;

    private Vector3 v3NowPosition;

    void UpDate()
    {
        v3NowPosition = this.transform.position;
    }
    
    // 座標を変更する.
    public void BasePositionChange(float x, float y, float z)
    {
        v3NowPosition = v3BasePosition = new Vector3(x, y, z);
    }

    public Vector3 BasePosition()
    {
        return v3BasePosition;
    }

    public Vector3 NowPosition()
    {
        return v3NowPosition;
    }

    // 現在の座標を返す.
    public float NowPositionOne(char xyz)
    {
        switch (xyz)
        {
            case 'x': return v3NowPosition.x;
            case 'y': return v3NowPosition.y;
            case 'z': return v3NowPosition.z;
        }
        return - 1.0f;
    }

    public void NowPositionYChange(float y)
    {
        v3NowPosition.y = y;
    }

    public float NowPositionZ()
    {
        return v3NowPosition.z;
    }
}