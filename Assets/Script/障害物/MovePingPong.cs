using UnityEngine;

[RequireComponent(typeof(Collider))]
public class MovePingPong : MonoBehaviour
{
    [Header("移動距離（往復の片道分）")]
    public float moveDistance = 3f;

    [Header("移動スピード")]
    public float speed = 2f;

    [Header("動き出すまでの遅延時間（秒）")]
    public float startDelay = 0f;

    [Header("移動方向")]
    public bool moveXPlus;
    public bool moveXMinus;
    public bool moveYPlus;
    public bool moveYMinus;
    public bool moveZPlus;
    public bool moveZMinus;

    private Vector3 startPos;
    private Vector3 moveDirection;
    private float elapsedTime;

    void Start()
    {
        startPos = transform.position;
        moveDirection = Vector3.zero;

        if (moveXPlus) moveDirection.x = 1;
        else if (moveXMinus) moveDirection.x = -1;
        if (moveYPlus) moveDirection.y = 1;
        else if (moveYMinus) moveDirection.y = -1;
        if (moveZPlus) moveDirection.z = 1;
        else if (moveZMinus) moveDirection.z = -1;

        moveDirection.Normalize();

        // コライダーを「isTrigger = false」にして、足場として機能させる
        Collider col = GetComponent<Collider>();
        if (col != null)
        {
            col.isTrigger = false;
        }
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime < startDelay) return;

        float offset = Mathf.PingPong((elapsedTime - startDelay) * speed, moveDistance);
        transform.position = startPos + moveDirection * offset;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // プレイヤーが乗ったとき、親子関係を設定
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // プレイヤーが降りたら親子関係を解除
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
