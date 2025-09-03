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

    [Header("ランダム座標設定")]
    [SerializeField] private RandomSettings randomSettings;

    [Header("回転する")]
    [SerializeField]
    private bool rotate = false;

    [Header("色を変えるスクリプト")]
    [SerializeField]
    public ColorChange ColorChange;

    [Header("座標管理スクリプト")]
    [SerializeField]
    public positionDate position;

    [Header("重力加速度")]
    [SerializeField]
    private float fGravity = -0.03f;

    [Header("オブジェクト消去の高さ")]
    [SerializeField]
    private float finishposition = 0.0f;


    void Start()
    {
        if (randomSettings.useRandom) randomSettings.script.RanPosition();
        v3BasePosition = position.BasePosition();
        v3Position = v3BasePosition;                    // 位置を初期化.
        v3Velocity = v3BaseVelocity;                    // 速度を初期化.
        transform.position = v3Position;
    }

    void Update()
    {
        v3Position += v3Velocity;       // 位置に速度を足す.
        v3Velocity.y += fGravity;       // 速度に加速度を足す.

        if ((fGravity > 0.0f && v3Position.y > finishposition) ||
            (fGravity <= 0.0f && v3Position.y < finishposition))
                Destroy(gameObject);     // y軸が規定値を上/下回ったらオブジェクト消去.

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
