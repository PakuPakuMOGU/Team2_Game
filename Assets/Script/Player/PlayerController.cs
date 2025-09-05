using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SimplePlayerControllerOldInput : MonoBehaviour
{
    private Rigidbody rb;

    public float speed = 5f;
    public float jumpForce = 5f;

    [Header("チェックポイントスクリプト")]
    public CheckPoint Check;

    private bool jumpRequested = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void Update()
    {
        // ジャンプ入力はUpdateで検知（フレーム毎）
        if (Input.GetButtonDown("Jump"))
        {
            jumpRequested = true;
        }
    }

    private void FixedUpdate()
    {
        // 移動入力を取得
        float moveX = Input.GetAxis("Horizontal"); // A/D or ←→キー
        float moveZ = Input.GetAxis("Vertical");   // W/S or ↑↓キー

        Vector3 move = new Vector3(moveX, 0, moveZ);

        Vector3 velocity = move.normalized * speed;
        velocity.y = rb.velocity.y; // 垂直速度は維持

        rb.velocity = velocity;

        // ジャンプ処理（地面判定なし）
        if (jumpRequested)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            jumpRequested = false;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        string tag = collider.gameObject.tag;
        Check.TagCheck(tag);
    }
}

/*
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
public float moveSpeed = 5f;
public float jumpForce = 7f;

private Rigidbody rb;
private bool isGrounded;

void Start()
{
    rb = GetComponent<Rigidbody>();
}

void Update()
{
    Move();
    Jump();
}

void Move()
{
    float moveX = Input.GetAxis("Horizontal");
    float moveZ = Input.GetAxis("Vertical");

    Vector3 move = new Vector3(moveX, 0f, moveZ) * moveSpeed;

    Vector3 velocity = rb.velocity;
    velocity.x = move.x;
    velocity.z = move.z;
    rb.velocity = velocity;
}

void Jump()
{
    // すべてのコライダーに対して地面チェックする
    isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);

    if (isGrounded && Input.GetKeyDown(KeyCode.Space))
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}

// 地面検出用Rayを確認したいときはここをON
private void OnDrawGizmosSelected()
{
    Gizmos.color = Color.red;
    Gizmos.DrawLine(transform.position, transform.position + Vector3.down * 1.1f);
}
}
*/