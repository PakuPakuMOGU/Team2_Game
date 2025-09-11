using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SimplePlayerControllerOldInput : MonoBehaviour
{
    private Rigidbody rb;

    public float speed = 5f;
    public float jumpForce = 5f;

    [Header("ƒ`ƒFƒbƒNƒ|ƒCƒ“ƒgƒXƒNƒŠƒvƒg")]
    public CheckPoint Check;

    private bool jumpRequested = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void Update()
    {
        // ƒWƒƒƒ“ƒv“ü—Í‚ÍUpdate‚ÅŒŸ’miƒtƒŒ[ƒ€–ˆj
        if (Input.GetButtonDown("Jump"))
        {
            jumpRequested = true;
        }
    }

    private void FixedUpdate()
    {
        // ˆÚ“®“ü—Í‚ğæ“¾
        float moveX = Input.GetAxis("Horizontal"); // A/D or ©¨ƒL[
        float moveZ = Input.GetAxis("Vertical");   // W/S or ª«ƒL[

        Vector3 move = new Vector3(moveX, 0, moveZ);
        Vector3 velocity = move.normalized * speed;
        velocity.y = rb.velocity.y; // ‚’¼‘¬“x‚ÍˆÛ

        rb.velocity = velocity;

<<<<<<< HEAD:Assets/Script/PlayerController.cs
        if (jumpRequested && isGrounded)
=======
        // ƒWƒƒƒ“ƒvˆ—i’n–Ê”»’è‚È‚µj
        if (jumpRequested)
>>>>>>> 6077e21 (Revert "ç„¡é™ã‚¸ãƒ£ãƒ³ãƒ—æ¶ˆãˆãŸï¼ˆèï¼‰"):Assets/Script/Player/PlayerController.cs
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            isGrounded = false; // ƒWƒƒƒ“ƒv’¼Œã‚É‹ó’†‚É‚·‚é
            jumpRequested = false;
        }
    }
<<<<<<< HEAD:Assets/Script/PlayerController.cs

    void OnTriggerEnter(Collider collider)
    {
        string tag = collider.gameObject.tag;
        Check.TagCheck(tag);
    }

    // ƒ^ƒO‚È‚µ‚Å’n–Ê‚Æ‚ÌÚG‚ğ”»’è
    private void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            // ÚG–Ê‚Ì–@ü‚ªã•ûŒüi’n–Êj‚É‹ß‚¯‚ê‚Î’n–Ê‚Æ‚İ‚È‚·
            if (Vector3.Dot(contact.normal, Vector3.up) > 0.5f)
            {
                isGrounded = true;
                return;
            }
        }
        // ãŒü‚«‚ÌÚG–Ê‚ª‚È‚¯‚ê‚Î false
        isGrounded = false;
    }

    private void OnCollisionExit(Collision collision)
    {
        // ÚG‚ª‚È‚­‚È‚Á‚½‚ç‹ó’†‚Æ‚İ‚È‚·
        isGrounded = false;
    }
}
=======
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
    // ‚·‚×‚Ä‚ÌƒRƒ‰ƒCƒ_[‚É‘Î‚µ‚Ä’n–Êƒ`ƒFƒbƒN‚·‚é
    isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);

    if (isGrounded && Input.GetKeyDown(KeyCode.Space))
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}

// ’n–ÊŒŸo—pRay‚ğŠm”F‚µ‚½‚¢‚Æ‚«‚Í‚±‚±‚ğON
private void OnDrawGizmosSelected()
{
    Gizmos.color = Color.red;
    Gizmos.DrawLine(transform.position, transform.position + Vector3.down * 1.1f);
}
}
*/
>>>>>>> 6077e21 (Revert "ç„¡é™ã‚¸ãƒ£ãƒ³ãƒ—æ¶ˆãˆãŸï¼ˆèï¼‰"):Assets/Script/Player/PlayerController.cs
