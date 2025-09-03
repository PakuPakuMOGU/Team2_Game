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
    [Header("ランダム速度設定する？")]
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
        if (updownSet.yes) updownSet.script.GivePositionY();                     // 上下に動く場合Yを反映させる.
        if (randomSpeedSet.yes)
        {
            speed = Random.Range(randomSpeedSet.min, randomSpeedSet.max);             // ランダム速度を使う場合ランダム計算.
            speed += (float)((Random.Range(0, 8) / 10) + 0.1);
        }

        fAngle_Vel += speed * Mathf.PI / 50.0f;
        v3Position = new Vector3(fRot_r * Mathf.Cos(fAngle_Vel), position.NowPositionOne('y'), fRot_r * Mathf.Sin(fAngle_Vel)); // 位置の計算.

        transform.position = v3Position;
    }
}
