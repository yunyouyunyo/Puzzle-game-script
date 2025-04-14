using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;      // 拖入玩家对象
    public float followDuration = 5f;  // 跟随持续时间（秒）
    public Vector3 offset = new Vector3(0.56f, 3.55f, 0);

    private bool isFollowing = false;

    void Start()
    {
        StartFollowing();  // 开始跟随
    }

    public void StartFollowing()
    {
        if (player != null)
        {
            isFollowing = true;
            StartCoroutine(FollowAndDisappearCoroutine());
        }
    }

    private IEnumerator FollowAndDisappearCoroutine()
    {
        float elapsed = 0f;

        while (elapsed < followDuration)
        {
            if (isFollowing)
            {
                // 跟随玩家的位置
                transform.position = player.position+offset;
                elapsed += Time.deltaTime;
            }

            yield return null;
        }

        // 跟随结束后，使物件消失或销毁
        gameObject.SetActive(false);  // 隐藏物件
        // 或者用Destroy(gameObject); // 销毁物件
    }
}
