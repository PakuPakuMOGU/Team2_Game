using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class positionDate : MonoBehaviour
{
    [Header("èâä˙ç¿ïW")]
    [SerializeField]
    private Vector3 v3BasePosition;

    private Vector3 v3NowPosition;

    void UpDate()
    {
        v3NowPosition = this.transform.position;
    }

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

    public float NowPositionX()
    {
        return v3NowPosition.x;
    }

    public float NowPositionY()
    {
        return v3NowPosition.y;
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
