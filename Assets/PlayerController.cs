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
        // 移動方向計算
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);

        // 移動処理
        Vector3 velocity = move.normalized * speed;
        velocity.y = rb.velocity.y;  // 垂直速度は維持

        rb.velocity = velocity;

        // ジャンプ処理（地面判定なし）
        if (jumpInput)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
            jumpInput = false;
        }
    }
}
