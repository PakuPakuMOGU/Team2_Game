using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SimplePlayerControllerOldInput : MonoBehaviour
{
    private Rigidbody rb;

    public float speed = 5f;
    public float jumpForce = 5f;

    [Header("�`�F�b�N�|�C���g�X�N���v�g")]
    public CheckPoint Check;

    private bool jumpRequested = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

    private void Update()
    {
        // �W�����v���͂�Update�Ō��m�i�t���[�����j
        if (Input.GetButtonDown("Jump"))
        {
            jumpRequested = true;
        }
    }

    private void FixedUpdate()
    {
        // �ړ����͂��擾
        float moveX = Input.GetAxis("Horizontal"); // A/D or �����L�[
        float moveZ = Input.GetAxis("Vertical");   // W/S or �����L�[

        Vector3 move = new Vector3(moveX, 0, moveZ);

        Vector3 velocity = move.normalized * speed;
        velocity.y = rb.velocity.y; // �������x�͈ێ�

        rb.velocity = velocity;

        // �W�����v�����i�n�ʔ���Ȃ��j
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
}
*/