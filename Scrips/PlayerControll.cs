using UnityEngine;
using System;

public class PlayerControll : MonoBehaviour
{
    public Rigidbody2D rb;
    public CharacterController2D controller;
    public float runSpeed = 0.5f;
    private float horizontalMove = 0f;


    public GameObject BulletPrefab;
    public Animator animator;

    private bool jump;
    private bool isWalking = false;
    public float stepInterval = 1f; // 步行聲音的間隔時間

    public Transform cabinet; // 柜子的位置
    private bool isInCabinet = false; // 玩家是否在柜子里
    private bool canEnterCabinet = false; // 玩家是否靠近柜子
    private SpriteRenderer spriteRenderer; // 玩家精灵渲染器
    private Collider2D playerCollider; // 玩家碰撞器

    public PolygonCollider2D cameraBoundary;
    private bool isCabinet = false;



    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerCollider = GetComponent<Collider2D>();
    }



    void Update()
    {
        //相機邊界
        float boundaryLeft = cameraBoundary.bounds.min.x;
        float boundaryRight = cameraBoundary.bounds.max.x;

        Vector3 playerPos = rb.transform.position;
        playerPos.x = Mathf.Clamp(playerPos.x, boundaryLeft, boundaryRight);
        rb.transform.position = playerPos;

        // 只有当玩家靠近柜子时，才能按 M 键进入或退出柜子
        if (canEnterCabinet && Input.GetKeyDown(KeyCode.Space))
        {
            if (isInCabinet)
            {
                ExitCabinet();

            }
            else
            {

                EnterCabinet();
            }
        }
        if (isCabinet)
        {
            horizontalMove = 0;
        }
        else
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        }


        if (horizontalMove != 0f)
        {
            if (!isWalking)
            {
                isWalking = true;
                AudioManager.Instance.PlaySFX("walk");
            }
        }
        else
        {
            isWalking = false;
            AudioManager.Instance.sfxSource.Stop();
        }

        animator.SetFloat("Speed", Math.Abs(horizontalMove));

    }

    private void FixedUpdate()
    {

        // 使用 CharacterController2D 的 Move 方法
        controller.Move(horizontalMove, false, jump);
        jump = false; // 只允许一次跳跃
    }

    public void OnTriggerStay2D(Collider2D coll)
    {



    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Cabinet"))
        {
            canEnterCabinet = true; // 玩家进入柜子附近
            Debug.Log("玩家靠近柜子，可以按 M 键进入或退出柜子");
        }
        if (other.gameObject.tag == "Portal")
        {
            other.gameObject.transform.GetComponent<Portal>().ChangeScene();

        }
        else if (other.gameObject.tag == "PortalLock")
        {
            other.gameObject.transform.GetComponent<PortalLock>().ChangeScene();
        }
        else if(other.gameObject.tag == "PortalLock4"){
            other.gameObject.transform.GetComponent<lockforbubble>().ChangeScene();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Cabinet"))
        {
            canEnterCabinet = false; // 玩家离开柜子附近
            Debug.Log("玩家离开柜子，不能按 M 键进入或退出");
        }
    }

    void EnterCabinet()
    {
        isInCabinet = true;
        spriteRenderer.enabled = false; // 隐藏玩家
        // playerCollider.enabled = false; // 禁用玩家的碰撞器，避免鬼魂检测到玩家
        Debug.Log("玩家进入柜子，隐藏并躲避鬼魂");
        isCabinet = true;
    }

    void ExitCabinet()
    {
        isInCabinet = false;
        spriteRenderer.enabled = true; // 恢复玩家显示
        playerCollider.enabled = true; // 恢复玩家的碰撞器
        Debug.Log("玩家退出柜子，恢复显示");
        isCabinet = false;
    }

    // 获取玩家是否在柜子里
    public bool IsInCabinet()
    {
        return isInCabinet;
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // 简单处理：让玩家停止移动
            rb.velocity = Vector2.zero;
        }
    }

}
