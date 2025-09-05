using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("追従対象")]
    public Transform target;

    [Header("カメラのオフセット")]
    public Vector3 offset = new Vector3(0f, 5f, -10f);

    [Header("追従スピード")]
    public float followSpeed = 5f;

    [Header("カメラの画角")]
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

        // 目標位置を計算
        Vector3 desiredPosition = target.position + offset;

        // 補間でスムーズに追従
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        // 対象を常に注視
        transform.LookAt(target);
    }
}
