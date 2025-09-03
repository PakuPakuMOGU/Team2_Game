using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class SimplePlayerController : MonoBehaviour
{
    private Vector2 moveInput = Vector2.zero;
    private bool jumpInput = false;

    private Rigidbody rb;

    public float speed = 5f;
    public float jumpForce = 5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            jumpInput = true;
        }
    }

    private void FixedUpdate()
    {
        // �ړ������v�Z
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);

        // �ړ�����
        Vector3 velocity = move.normalized * speed;
        velocity.y = rb.velocity.y;  // �������x�͈ێ�

        rb.velocity = velocity;

        // �W�����v�����i�n�ʔ���Ȃ��j
        if (jumpInput)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            jumpInput = false;
        }
    }
}
