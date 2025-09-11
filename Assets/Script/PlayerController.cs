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
    private bool isGrounded = false;

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

        Vector3 move = new Vector3(moveX, 0, moveZ);
        Vector3 velocity = move.normalized * speed;
        velocity.y = rb.velocity.y;

        rb.velocity = velocity;

        if (jumpRequested && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            isGrounded = false; // ジャンプ直後に空中にする
            jumpRequested = false;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        string tag = collider.gameObject.tag;
        Check.TagCheck(tag);
    }

    // タグなしで地面との接触を判定
    private void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            // 接触面の法線が上方向（地面）に近ければ地面とみなす
            if (Vector3.Dot(contact.normal, Vector3.up) > 0.5f)
            {
                isGrounded = true;
                return;
            }
        }
        // 上向きの接触面がなければ false
        isGrounded = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        // 接触がなくなったら空中とみなす
        isGrounded = false;
    }
}