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

<<<<<<< HEAD:Assets/Script/PlayerController.cs
<<<<<<< HEAD:Assets/Script/PlayerController.cs
        if (jumpRequested && isGrounded)
=======
        // ƒWƒƒƒ“ƒvˆ—i’n–Ê”»’è‚È‚µj
=======
>>>>>>> 07dcda6 (no message):Assets/Script/Player/PlayerController.cs
        if (jumpRequested)
>>>>>>> 6077e21 (Revert "ç„¡é™ã‚¸ãƒ£ãƒ³ãƒ—æ¶ˆãˆãŸï¼ˆèï¼‰"):Assets/Script/Player/PlayerController.cs
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            isGrounded = false; // ƒWƒƒƒ“ƒv’¼Œã‚É‹ó’†‚É‚·‚é
            jumpRequested = false;
        }
    }
<<<<<<< HEAD:Assets/Script/PlayerController.cs
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
=======
>>>>>>> 07dcda6 (no message):Assets/Script/Player/PlayerController.cs

    // ’n–Ê‚ÆÚG‚µ‚Ä‚¢‚ê‚Î isGrounded = true
    private void OnCollisionStay(Collision collision)
    {
        isGrounded = true;
    }

    // ÚG‚ªI‚í‚Á‚½‚ç isGrounded = false
    private void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
<<<<<<< HEAD:Assets/Script/PlayerController.cs

// ’n–ÊŒŸo—pRay‚ğŠm”F‚µ‚½‚¢‚Æ‚«‚Í‚±‚±‚ğON
private void OnDrawGizmosSelected()
{
    Gizmos.color = Color.red;
    Gizmos.DrawLine(transform.position, transform.position + Vector3.down * 1.1f);
}
}
*/
>>>>>>> 6077e21 (Revert "ç„¡é™ã‚¸ãƒ£ãƒ³ãƒ—æ¶ˆãˆãŸï¼ˆèï¼‰"):Assets/Script/Player/PlayerController.cs
=======
>>>>>>> 07dcda6 (no message):Assets/Script/Player/PlayerController.cs
