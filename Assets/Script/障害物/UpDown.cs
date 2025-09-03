using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDown : MonoBehaviour
{
    private Vector3 v3BasePosition;
    private Vector3 v3BaseVelocity = new Vector3(0.0f, 0.0f, 0.0f);
    private Vector3 v3Position;
    private Vector3 v3Velocity;

    [System.Serializable]
    public class RandomSettings
    {
        public bool useRandom = false;
        public RandomPosition script;
    }

    [Header("�����_�����W�ݒ�")]
    [SerializeField] private RandomSettings randomSettings;

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
        if (randomSettings.useRandom) randomSettings.script.RanPosition();
        v3BasePosition = position.BasePosition();
        v3Position = v3BasePosition;                    // �ʒu��������.
        v3Velocity = v3BaseVelocity;                    // ���x��������.
        transform.position = v3Position;
    }

    void Update()
    {
        v3Position += v3Velocity;       // �ʒu�ɑ��x�𑫂�.
        v3Velocity.y += fGravity;       // ���x�ɉ����x�𑫂�.

        if ((fGravity > 0.0f && v3Position.y > finishposition) ||
            (fGravity <= 0.0f && v3Position.y < finishposition))
                Destroy(gameObject);     // y�����K��l����/���������I�u�W�F�N�g����.

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
