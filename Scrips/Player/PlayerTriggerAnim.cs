using UnityEngine;

public class PlayerTriggerAnim : MonoBehaviour
{
    public Animator boxAnimator; // 箱子的动画
    public Animator playerAnimator; // 玩家动画
    public GameObject space;

    private bool isBoxMove = false; // 用于追踪是否正在推动箱子
    private float pushSpeed = 5f; // 推箱子的速度
    public bool move = false;

    void Start()
    {
        playerAnimator.SetInteger("Boxspeed", 0);
    }
    private void Update()
    {
        playerAnimator.SetInteger("Boxspeed", 0);
        if (Input.GetKey(KeyCode.Space))
        {
            playerAnimator.SetInteger("Boxspeed", 1);

        }

        // 检测松开J键时停止推动动画
        if (Input.GetKeyUp(KeyCode.Space) || !isBoxMove)
        {
            isBoxMove = false;
            playerAnimator.SetInteger("Boxspeed", 0);
        }

    }

    private void OnTriggerStay2D(Collider2D other)
    {
        // 检查是否是玩家与箱子互动
        if (gameObject.CompareTag("Box") && other.CompareTag("Player") && Input.GetKey(KeyCode.Space))
        {
            Rigidbody2D boxRb = gameObject.GetComponent<Rigidbody2D>();
            

            if (boxRb != null && boxRb.isKinematic)
            {
                // 获取水平输入方向，仅允许左右推动
                float horizontalInput = Input.GetAxis("Horizontal");
                float playerX = other.transform.position.x;
                float tolerance = 0.1f;

                // 检查 Player 是否在 Box 左侧或右侧
                if ((playerX < gameObject.GetComponent<Collider2D>().bounds.min.x - tolerance && horizontalInput > 0) ||
                    (playerX > gameObject.GetComponent<Collider2D>().bounds.max.x + tolerance && horizontalInput < 0))
                {
                    // 按照输入方向移动箱子，仅允许在两侧推动
                    Vector2 pushDirection = new Vector2(horizontalInput, 0);
                    boxRb.transform.Translate(pushDirection * pushSpeed * Time.deltaTime);

                    // 设置推动状态和动画参数
                    isBoxMove = true;
                    boxAnimator.enabled = false; // 暂时关闭箱子动画（可选）
                    Destroy(space);
                    // playerAnimator.SetInteger("Boxspeed", 1); // 播放推动动画
                    move = true;
                }
                else
                {
                    // 玩家不在箱子两侧时停止动画
                    isBoxMove = false;
                    // playerAnimator.SetInteger("Boxspeed", 0);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // 玩家离开触发区域时停止动画
        if (other.CompareTag("Player"))
        {
            isBoxMove = false;
            // playerAnimator.SetInteger("Boxspeed", 0);
        }
    }
}
