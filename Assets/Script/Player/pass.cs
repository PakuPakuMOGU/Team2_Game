using UnityEngine;
using UnityEngine.UI;

public class CompassUI : MonoBehaviour
{
    public Transform cameraTransform; // カメラを指定
    public RectTransform compassImage; // UIのコンパス画像 (Image or RawImage)

    void Update()
    {
        if (cameraTransform == null || compassImage == null) return;

        // カメラのY軸の角度（水平回転）を取得
        float yRotation = cameraTransform.eulerAngles.y;

        // UIを反転回転させて北を固定する
        compassImage.localRotation = Quaternion.Euler(0, 0, -yRotation);
    }
}
