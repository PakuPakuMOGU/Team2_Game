using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPosition : MonoBehaviour
{
    [Header("���W�ݒ�X�N���v�g")]
    [SerializeField]
    public positionDate position;

    [Header("���W�̏��")]
    [SerializeField]
    private Vector3 max = new Vector3(20, 20, 20);

    [Header("���W�̉���")]
    [SerializeField]
    private Vector3 min = new Vector3(20, 20, 20);

    public void RanPosition()
    {
        float x, y, z;

        x = Random.Range(min.x, max.x);
        y = Random.Range(min.y, max.y);
        z = Random.Range(min.z, max.z);

        position.BasePositionChange(x, y, z);
    }
}