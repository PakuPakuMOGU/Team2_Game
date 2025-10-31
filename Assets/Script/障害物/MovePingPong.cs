using UnityEngine;

[RequireComponent(typeof(Collider))]
public class MovePingPong : MonoBehaviour
{
    [Header("移動距離（往復の片道分）")]
    public float moveDistance = 3f;

    [Header("移動スピード")]
    public float speed = 2f;

    [Header("動き出すまでの遅延時間（秒）")]
    public float startDelay = 0f;

    [Header("プレイヤーが上にいる間だけ動く")]
    public bool startOnPlayer = true;

    [Header("降りたら止まる")]
    public bool stopWhenPlayerLeaves = true;

    [Header("離れても動き続ける時間（秒）")]
    public float stayActiveAfterLeave = 0.3f;

    [Header("移動方向")]
    public bool moveXPlus;
    public bool moveXMinus;
    public bool moveYPlus;
    public bool moveYMinus;
    public bool moveZPlus;
    public bool moveZMinus;

    private Vector3 startPos;
    private Vector3 endPos;
    private Vector3 moveDirection;
    private float elapsedTime;
    private bool movingForward = true;
    private bool isActive = false; // 動いているかどうか
    private bool playerOn = false;
    private float lastPlayerTime;

    void Start()
    {
        startPos = transform.position;

        // 移動方向を設定
        moveDirection = Vector3.zero;
        if      (moveXPlus)  moveDirection.x =  1;
        else if (moveXMinus) moveDirection.x = -1;
        if      (moveYPlus)  moveDirection.y =  1;
        else if (moveYMinus) moveDirection.y = -1;
        if      (moveZPlus)  moveDirection.z =  1;
        else if (moveZMinus) moveDirection.z = -1;

        moveDirection.Normalize();
        endPos = startPos + moveDirection * moveDistance;

        Collider col = GetComponent<Collider>();
        col.isTrigger = false;
    }

    void Update()
    {
        // プレイヤー起動モード
        if (startOnPlayer)
        {
            if (!isActive)
            {
                // プレイヤーが乗っていなければ停止
                if (!playerOn && Time.time - lastPlayerTime > stayActiveAfterLeave)
                    return;
            }
        }

        // 動作中
        if (!isActive && (playerOn || !startOnPlayer))
        {
            StartCoroutine(MovePlatform());
        }
    }

    private System.Collections.IEnumerator MovePlatform()
    {
        isActive = true;
        elapsedTime = 0f;

        yield return new WaitForSeconds(startDelay);

        // 片道移動
        while (Vector3.Distance(transform.position, movingForward ? endPos : startPos) > 0.01f)
        {
            Vector3 target = movingForward ? endPos : startPos;
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
            yield return null;

            // 降りたら止まる処理
            if (stopWhenPlayerLeaves && startOnPlayer)
            {
                if (!playerOn && Time.time - lastPlayerTime > stayActiveAfterLeave)
                {
                    isActive = false;
                    yield break;
                }
            }
        }

        transform.position = movingForward ? endPos : startPos;

        // 一往復したら戻す
        if (!movingForward)
        {
            // 開始地点に戻ったので停止
            isActive = false;
            yield break;
        }

        // 戻る
        movingForward = !movingForward;
        yield return StartCoroutine(MovePlatform());

        // 最初に戻ったら完全停止
        movingForward = true;
        isActive = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
            playerOn = true;
            lastPlayerTime = Time.time;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            playerOn = true;
            lastPlayerTime = Time.time;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
            playerOn = false;
        }
    }
}
