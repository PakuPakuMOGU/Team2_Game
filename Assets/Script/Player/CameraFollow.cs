// CameraFollow.cs
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("追従対象")]
    public Transform target;

    [Header("カメラの距離と高さ")]
    public float distance = 6.0f;
    public float height = 3.0f;

    [Header("回転感度")]
    public float mouseSensitivity = 3.0f;

    [Header("カメラ回転の制限")]
    public float minYAngle = -20f;
    public float maxYAngle = 80f;

    [Header("追従スピード")]
    public float followSpeed = 10f;

    private float rotationX = 0f;
    private float rotationY = 0f;

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

        // マウス入力を取得
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        // カメラの回転角度を更新
        rotationY += mouseX; // 水平方向（左右）
        rotationX -= mouseY; // 垂直方向（上下）
        rotationX = Mathf.Clamp(rotationX, minYAngle, maxYAngle); // 上下の回転角度を制限

        // カメラの回転をクォータニオンで作成
        Quaternion rotation = Quaternion.Euler(rotationX, rotationY, 0);

        // 追従対象の位置 + 高さ
        Vector3 targetPosition = target.position + Vector3.up * height;

        // カメラの位置を計算（rotation を使って target の周りを回る）
        Vector3 cameraOffset = rotation * new Vector3(0, 0, -distance);
        Vector3 desiredPosition = targetPosition + cameraOffset;

        // カメラの位置を滑らかに補間
        transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);

        // カメラが常にプレイヤーを見るように
        transform.LookAt(targetPosition);
    }
}
