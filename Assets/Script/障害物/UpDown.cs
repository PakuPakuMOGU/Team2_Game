using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class down : MonoBehaviour
{
    private Vector3 v3BasePosition;
    private Vector3 v3BaseVelocity = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 v3Position;
    private Vector3 v3Velocity;

    [Header("�����_�����W���g��")]
    [SerializeField]
    private bool rand = false;

    [Header("�����_�����W�X�N���v�g")]
    [SerializeField]
    private RandomPosition rand_s;

    [Header("��]����")]
    [SerializeField]
    private bool rotate = false;

    [Header("�F��ς���X�N���v�g")]
    [SerializeField]
    public ColorChange ColorChange;

    [Header("���W�Ǘ��X�N���v�g")]
    [SerializeField]
    public positionDate position;

    [Header("�d�͉����x")]
    [SerializeField]
    private float fGravity = -0.03f;

    [Header("�I�u�W�F�N�g�����̍���")]
    [SerializeField]
    private float finishposition = 0.0f;


    void Start()
    {
        if (rand)   rand_s.RanPosition();
        v3BasePosition = position.BasePosition();
        v3Position = v3BasePosition;                    // �ʒu��������.
        v3Velocity = v3BaseVelocity;                    // ���x��������.
        transform.position = v3Position;
    }

    void Update()
    {
        v3Position += v3Velocity;       // �ʒu�ɑ��x�𑫂�.
        v3Velocity.y += fGravity;       // ���x�ɉ����x�𑫂�.

        if (fGravity > 0.0f)
        {
            if (v3Position.y > finishposition)
                Destroy(gameObject);        // y�����K��l���z������I�u�W�F�N�g����.
        }
        else
        {
            if (v3Position.y < finishposition)
                Destroy(gameObject);        // y�����K��l�����������I�u�W�F�N�g����.
        }

        if (!rotate)
        {
            transform.position = v3Position;
        }
    }

    public void GivePositionY()
    {
        position.NowPositionYChange(v3Position.y);
    }
}
