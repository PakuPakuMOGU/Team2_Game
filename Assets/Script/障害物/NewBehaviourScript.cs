using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class MovingPlatform : MonoBehaviour
{
    [Header("移動設定")]
    public bool moveX = true;
    public bool moveY = false;
    public bool moveZ = false;
    public float distance = 3f;       // 片道の距離
    public float speed = 1f;          // 動く速さ
    public bool smooth = false;       // なめらかにする（PingPongにLerpを組み合わせる）

    [Header("接触設定")]
    public LayerMask passengerMask = ~0;   // どのレイヤーを"乗客"として扱うか（デフォルト：すべて）
    public bool useParentingForNonRigidbody = true; // Rigidbodyを持たないオブジェクトは親にするか

    Vector3 startPos;
    Vector3 lastPos;
    Vector3 moveDir;

    // 乗客リスト
    HashSet<Rigidbody> passengersRB = new HashSet<Rigidbody>();
    Dictionary<Transform, Transform> originalParents = new Dictionary<Transform, Transform>();

    void Start()
    {
        startPos = transform.position;
        lastPos = startPos;
        moveDir = new Vector3(moveX ? 1f : 0f, moveY ? 1f : 0f, moveZ ? 1f : 0f).normalized;
        // 警告: moveDirがゼロだと動かないので注意
        if (moveDir == Vector3.zero)
        {
            Debug.LogWarning("MovingPlatform: move direction is zero. Enable at least one axis (X/Y/Z).");
            moveDir = Vector3.up;
        }

        // Colliderはトリガーではなく衝突用にするのが基本（必要に応じてTrigger版も作れます）
        Collider col = GetComponent<Collider>();
        if (col.isTrigger) Debug.LogWarning("MovingPlatform: Collider is trigger. OnCollision won't be called. If using Trigger, adapt the script.");
    }

    void FixedUpdate()
    {
        // PingPongで 0..distance..0 を作る
        float t = Mathf.PingPong(Time.time * speed, distance);
        Vector3 newPos = startPos + moveDir * t;

        if (smooth)
            transform.position = Vector3.Lerp(transform.position, newPos, 0.2f); // 任意の滑らかさ
        else
            transform.position = newPos;

        // プラットフォームの移動量を計算
        Vector3 delta = transform.position - lastPos;

        if (delta != Vector3.zero)
        {
            // Rigidbodyの乗客を移動（配列コピーでループ中の変更を安全に）
            Rigidbody[] rbs = new Rigidbody[passengersRB.Count];
            passengersRB.CopyTo(rbs);
            foreach (var rb in rbs)
            {
                if (rb == null) { passengersRB.Remove(rb); continue; }
                // MovePositionで移動させる（物理演算に優しい）
                rb.MovePosition(rb.position + delta);
            }
        }

        lastPos = transform.position;
    }

    // 上面からの接触のみを"乗った"と判定する補助
    bool ContactFromTop(Collision col)
    {
        foreach (var cp in col.contacts)
        {
            // contact.normal が上向き（プラットフォーム側の法線が上）なら上から接触
            if (Vector3.Dot(cp.normal, Vector3.up) > 0.5f) return true;
        }
        return false;
    }

    void OnCollisionEnter(Collision col)
    {
        if (((1 << col.gameObject.layer) & passengerMask) == 0) return; // レイヤーでフィルタ
        if (!ContactFromTop(col)) return; // 側面衝突は無視

        Rigidbody rb = col.rigidbody;
        if (rb != null && !rb.isKinematic)
        {
            passengersRB.Add(rb);
        }
        else if (useParentingForNonRigidbody)
        {
            Transform t = col.transform;
            if (!originalParents.ContainsKey(t))
                originalParents[t] = t.parent;
            t.SetParent(transform, true);
        }
    }

    void OnCollisionExit(Collision col)
    {
        Rigidbody rb = col.rigidbody;
        if (rb != null)
        {
            passengersRB.Remove(rb);
        }
        else if (useParentingForNonRigidbody)
        {
            Transform t = col.transform;
            // 元の親に戻す（保存がなければ null）
            if (originalParents.TryGetValue(t, out var orig))
            {
                t.SetParent(orig, true);
                originalParents.Remove(t);
            }
            else
            {
                t.SetParent(null, true);
            }
        }
    }

    // （必要ならTrigger版も）
    void OnTriggerEnter(Collider other)
    {
        // Trigger を使う場合の処理（同様に上面判定を追加した方が良い）
        // 実装は上のOnCollisionEnterと同様にできます。
    }
}
