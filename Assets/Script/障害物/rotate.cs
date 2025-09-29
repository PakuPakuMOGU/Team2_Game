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
    [Header("ランダム速度設定する？")]
    [SerializeField] private RandomSpeed randomSpeedSet;

    [System.Serializable]
    public class UpOrDown
    {
        public bool yes = false;
        public UpDown script;
    }
    [Header("上下移動させる？")]
    [SerializeField] private UpOrDown updownSet;

    [Header("座標設定スクリプト")]
    [SerializeField]
    public positionDate position;

    [Header("回転半径")]
    [SerializeField]
    private float fRot_r = 5.0f;

    [Header("速度")]
    [SerializeField]
    private float speed = 2.0f;

    [Header("初期角度")]
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
        fAngle_Vel = StartAngle * (speed * Mathf.PI / 50.0f);     // 初期角度を使って最初の位置を設定.
    }

    void FixedUpdate()
    {
        if (updownSet.yes) updownSet.script.GivePositionY();
        if (randomSpeedSet.yes)
        {
            speed = Random.Range(randomSpeedSet.min, randomSpeedSet.max);
            speed += (float)((Random.Range(0, 8) / 10) + 0.1);
        }

        fAngle_Vel += speed * Mathf.PI / 50.0f;

        Vector3 basePos = position.BasePosition(); // 回転の中心を取得
        float y = position.NowPositionOne('y');    // Y座標は別途取得

        v3Position = new Vector3(
            basePos.x + fRot_r * Mathf.Cos(fAngle_Vel),
            y,
            basePos.z + fRot_r * Mathf.Sin(fAngle_Vel)
        );

        transform.position = v3Position;
    }
}
