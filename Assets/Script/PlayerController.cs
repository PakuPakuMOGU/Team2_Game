using UnityEngine;
<<<<<<< HEAD
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
=======

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
        // ���ׂẴR���C�_�[�ɑ΂��Ēn�ʃ`�F�b�N����
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 1.1f);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // �n�ʌ��o�pRay���m�F�������Ƃ��͂�����ON
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * 1.1f);
    }
>>>>>>> 1519f0f4012a48036adea5b46dfda57af160e8d0
}
