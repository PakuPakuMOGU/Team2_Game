using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    [Header("移動設定")]
    public float walkSpeed = 5f;         // 通常移動速度
    public float dashSpeed = 10f;        // ダッシュ時の速度
    public float jumpForce = 5f;         // ジャンプ力

    [Header("チェックポイントスクリプト")]
    public CheckPoint Check;

    [Header("カメラのTransform")]
    public Transform cameraTransform;

    private bool jumpRequested = false;
    private bool isGrounded = false;
    private int jumpCount = 0;           // ジャンプ回数管理
    private bool isDashing = false;      // ダッシュ中かどうか

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void Update()
    {
        // ジャンプ入力：ジャンプ回数が2回未満のときだけ受付
        if (Input.GetButtonDown("Jump") && jumpCount < 2)
        {
            jumpRequested = true;
        }
    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 input = new Vector3(moveX, 0f, moveZ).normalized;

        // カメラの向きから移動方向を決定（Y軸方向は無視）
        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;

        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        // カメラ基準で移動ベクトルを変換
        Vector3 move = camForward * input.z + camRight * input.x;

        // ダッシュキー（左Ctrl）を押しているか判定
        isDashing = Input.GetKey(KeyCode.LeftControl);
        float currentSpeed = isDashing ? dashSpeed : walkSpeed;


        // 水平方向の移動速度を設定（Yは現在の速度を維持）
        Vector3 velocity = move * currentSpeed;
        velocity.y = rb.velocity.y;

        rb.velocity = velocity;

        // ジャンプ処理
        if (jumpRequested)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            jumpCount++; // ジャンプ回数加算
            isGrounded = false;
            jumpRequested = false;
        }
    }

    // チェックポイントのタグ処理
    void OnTriggerEnter(Collider collider)
    {
        string tag = collider.gameObject.tag;
        Check.TagCheck(tag);
    }

    // 地面に接触している間の処理（地面判定）
    private void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (Vector3.Dot(contact.normal, Vector3.up) > 0.5f)
            {
                isGrounded = true;
                jumpCount = 0; // 接地時にジャンプ回数リセット
                return;
            }
        }

        isGrounded = false;
    }

    // 地面から離れたとき
    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
