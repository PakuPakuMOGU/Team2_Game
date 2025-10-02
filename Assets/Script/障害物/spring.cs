using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Spring : MonoBehaviour
{
    [Header("打ち上げの強さ")]
    public float launchForce = 10f;

    

    private void Start()
    {
        // 物理接触を検知するため、isTriggerはオフにしておく
        GetComponent<Collider>().isTrigger = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                // 垂直方向に瞬間的な力を加える
                rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z); // 上方向に安定した打ち上げをするためY速度をリセット
                rb.AddForce(Vector3.up * launchForce, ForceMode.Impulse);
            }

          
        }
    }
}
