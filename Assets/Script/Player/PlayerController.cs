using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    public float speed = 5f;
    public float jumpForce = 5f;

    [Header("チェックポイントスクリプト")]
    public CheckPoint Check;

    [Header("カメラのTransform")]
    public Transform cameraTransform;

    private bool jumpRequested = false;
    private bool isGrounded = false;
    private int jumpCount = 0; // ジャンプ回数を管理

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void Update()
    {
        // ジャンプが1回以内ならジャンプ可能
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

        Vector3 camForward = cameraTransform.forward;
        Vector3 camRight = cameraTransform.right;

        camForward.y = 0;
        camRight.y = 0;
        camForward.Normalize();
        camRight.Normalize();

        Vector3 move = camForward * input.z + camRight * input.x;

        Vector3 velocity = move * speed;
        velocity.y = rb.velocity.y;

        rb.velocity = velocity;

        if (jumpRequested)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            jumpCount++; // ジャンプ回数を加算
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
                jumpCount = 0; // 地面に着いたらジャンプ回数リセット
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
