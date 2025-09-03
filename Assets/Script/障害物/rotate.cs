using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    [Header("�����_���ɑ��x��ݒ肷��")]
    [SerializeField]
    private bool rand = false;

    [Header("�����_�����x����")]
    [SerializeField]
    private int rand_min = 1;

    [Header("�����_�����x���")]
    [SerializeField]
    private int rand_max = 3;

    [Header("Y�������ֈړ�����")]
    [SerializeField]
    private bool running = false;

    [Header("�d�̓X�N���v�g")]
    [SerializeField]
    public down updown;

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
        if (running) updown.GivePositionY();                     // �㉺�ɓ����ꍇY�𔽉f������.
        if (rand)
        {
            speed = Random.Range(rand_min, rand_max);             // �����_�����x���g���ꍇ�����_���v�Z.
            speed += (float)((Random.Range(0, 8) / 10) + 0.1);
        }

        fAngle_Vel += speed * Mathf.PI / 50.0f;
        v3Position = new Vector3(fRot_r * Mathf.Cos(fAngle_Vel), position.NowPositionY(), fRot_r * Mathf.Sin(fAngle_Vel)); // �ʒu�̌v�Z.

        transform.position = v3Position;
    }
}
