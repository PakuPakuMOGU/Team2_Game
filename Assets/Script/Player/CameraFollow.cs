using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("追従対象")]
    public Transform target;

    [Header("カメラの距離と高さ")]
    public float distance = 5.0f;
    public float height = 2.0f;

    [Header("回転感度")]
    public float mouseSensitivity = 3.0f;

    [Header("カメラ回転の制限")]
    public float minYAngle = -20f;
    public float maxYAngle = 80f;

    [Header("追従スピード")]
    public float followSpeed = 10f;

    private float rotationX = 0f; // 上下回転角
    private float rotationY = 0f; // 左右回転角

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Vector3 angles = transform.eulerAngles;
        rotationY = angles.y;
        rotationX = angles.x;
    }

    void LateUpdate()
    {
        if (target == null) return;

        // マウス入力取得
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // 回転角を更新（上下方向は制限する）
        rotationY += mouseX;
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, minYAngle, maxYAngle);

        // 回転からカメラの位置を計算
        Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0);
        Vector3 targetPosition = target.position + Vector3.up * height;
        Vector3 cameraPosition = targetPosition - rotation * Vector3.forward * distance;

        // カメラを滑らかに移動
        transform.position = Vector3.Lerp(transform.position, cameraPosition, followSpeed * Time.deltaTime);

        // カメラの向きをターゲットに向ける
        transform.LookAt(targetPosition);
    }
}


