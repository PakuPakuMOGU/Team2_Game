using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("�Ǐ]�Ώ�")]
    public Transform target;

    [Header("�J�����̃I�t�Z�b�g")]
    public Vector3 offset = new Vector3(0f, 5f, -10f);

    [Header("�Ǐ]�X�s�[�h")]
    public float followSpeed = 5f;

    [Header("�J�����̉�p")]
    public float fixedFOV = 60f;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
        if (cam != null)
        {
            cam.fieldOfView = fixedFOV;
        }
    }

    void LateUpdate()
    {
        if (target == null) return;

        // �ڕW�ʒu���v�Z
        Vector3 desiredPosition = target.position + offset;

        // ��ԂŃX���[�Y�ɒǏ]
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        // �Ώۂ���ɒ���
        transform.LookAt(target);
    }
}
