using UnityEngine;
using UnityEngine.SceneManagement; // 导入场景管理命名空间
using System.Collections;


public class GhostController : MonoBehaviour
{
    public Transform player; // 玩家对象的引用
    private PlayerControll playerControll; // 玩家脚本的引用
    public float detectionRange = 5f; // 鬼魂检测玩家的范围

    public float speed = 2f; // 移动速度
    public Transform leftPoint; // 左边界点
    public Transform rightPoint; // 右边界点
    private bool movingRight = true; // 当前移动方向
    public CanvasGroup blackScreen;

    void Start()
    {
        // 获取玩家的 PlayerControll 脚本
        playerControll = player.GetComponent<PlayerControll>();
    }

    void Update()
    {
        // 鬼魂左右移动的逻辑
        if (movingRight)
        {
            transform.position = Vector2.MoveTowards(transform.position, rightPoint.position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, rightPoint.position) < 0.1f)
            {
                movingRight = false;
                Flip();
            }
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, leftPoint.position, speed * Time.deltaTime);
            if (Vector2.Distance(transform.position, leftPoint.position) < 0.1f)
            {
                movingRight = true;
                Flip();
            }
        }

        // 检查鬼魂和玩家之间的距离
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // 如果玩家没有在柜子里，鬼魂开始追踪玩家
        if (distanceToPlayer <= detectionRange && !playerControll.IsInCabinet())
        {
            ChasePlayer();
        }
    }

    void ChasePlayer()
    {
        // 这里可以编写追踪玩家的代码，比如移动到玩家的位置
        transform.position = Vector2.MoveTowards(transform.position, player.position, Time.deltaTime * 2f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // 如果鬼魂碰到玩家，重新加载场景
        if (other.CompareTag("Player") && !playerControll.IsInCabinet())
        {
            StartCoroutine(ReloadSceneWithDelay(1f));
        }
    }
    IEnumerator ReloadSceneWithDelay(float delay)
    {
        yield return StartCoroutine(FadeToBlack());
        yield return new WaitForSeconds(delay); // 等待指定的时间
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Debug.Log("场景重新加载");
    }

    IEnumerator FadeToBlack()
    {
        float duration = 1f; // 淡入持续时间
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            blackScreen.alpha = Mathf.Clamp01(elapsed / duration);
            yield return null;
        }
    }
    void Flip()
    {
        // 翻转鬼魂的X轴以改变朝向
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
