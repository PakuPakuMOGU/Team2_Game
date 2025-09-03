using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    [System.Serializable]
    public class RandomSpeed
    {
        public bool yes = false;
        public int min = 1;
        public int max = 3;
    }
    [Header("�����_�����x�ݒ肷��H")]
    [SerializeField] private RandomSpeed randomSpeedSet;

    [System.Serializable]
    public class UpOrDown
    {
        public bool yes = false;
        public UpDown script;
    }
    [Header("�����_�����x�ݒ肷��H")]
    [SerializeField] private UpOrDown updownSet;

    [Header("���W�ݒ�X�N���v�g")]
    [SerializeField]
    public positionDate position;

    [Header("��]���a")]
    [SerializeField]
    private float fRot_r = 5.0f;

    [Header("���x")]
    [SerializeField]
    private float speed = 2.0f;

    [Header("�����p�x")]
    [SerializeField]
    private int StartAngle = 0;

    private float fAngle_Vel;
    private Vector3 v3Velocity;
    private Vector3 v3Position;

    void Start()
    {
        Vector3 v3Velocity = new Vector3(0.0f, 0.0f, fRot_r * fAngle_Vel);

        v3Position = position.BasePosition();
        transform.position = v3Position;
        fAngle_Vel = StartAngle * (speed * Mathf.PI / 50.0f);     // �����p�x���g���čŏ��̈ʒu��ݒ�.
    }

    void FixedUpdate()
    {
        if (updownSet.yes) updownSet.script.GivePositionY();                     // �㉺�ɓ����ꍇY�𔽉f������.
        if (randomSpeedSet.yes)
        {
            speed = Random.Range(randomSpeedSet.min, randomSpeedSet.max);             // �����_�����x���g���ꍇ�����_���v�Z.
            speed += (float)((Random.Range(0, 8) / 10) + 0.1);
        }

        fAngle_Vel += speed * Mathf.PI / 50.0f;
        v3Position = new Vector3(fRot_r * Mathf.Cos(fAngle_Vel), position.NowPositionOne('y'), fRot_r * Mathf.Sin(fAngle_Vel)); // �ʒu�̌v�Z.

        transform.position = v3Position;
    }
}
