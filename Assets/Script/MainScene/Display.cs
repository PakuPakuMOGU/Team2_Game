using UnityEngine;

public class Display : MonoBehaviour
{
    public GameObject Player;

    void Update()
    {
        if (Player != null)
        {
            // Y軸だけでプレイヤーの方向を向く
            Vector3 targetPosition = new Vector3(
                Player.transform.position.x,
                transform.position.y,
                Player.transform.position.z
            );
            transform.LookAt(targetPosition);

            // モデルの正面がZ軸でない場合、Y軸を180度回転して補正
            transform.Rotate(0f, 180f, 0f);
        }
    }
}