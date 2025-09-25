using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    public float speed = 5f;
    public float jumpForce = 5f;

    [Header("チェックポイントスクリプト")]
    public CheckPoint Check;

    private bool jumpRequested = false;
    private bool isGrounded = false;

    [Header("カメラのTransform")]
    public Transform cameraTransform;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpRequested = true;
        }
    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // 入力ベクトル
        Vector3 input = new Vector3(moveX, 0f, moveZ).normalized;

        // カメラの向きから前方向と右方向を取得（Y軸だけの向きにする）
        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;

        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        // 入力をカメラ基準で変換（カメラの正面がプレイヤーの前になる）
        Vector3 move = camForward * input.z + camRight * input.x;

        Vector3 velocity = move * speed;
        velocity.y = rb.velocity.y;

        rb.velocity = velocity;

        if (jumpRequested && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            isGrounded = false;
            jumpRequested = false;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        string tag = collider.gameObject.tag;
        Check.TagCheck(tag);
    }

    private void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            if (Vector3.Dot(contact.normal, Vector3.up) > 0.5f)
            {
                isGrounded = true;
                return;
            }
        }
        isGrounded = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}