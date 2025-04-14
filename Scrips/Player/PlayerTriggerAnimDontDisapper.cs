using UnityEngine;


public class PlayerTriggerAnimDontDisapper : MonoBehaviour
{
    public GameObject targetObject;
    public Animator targetAnimator;    // 指向物件的 Animator 组件
    public string animationTriggerName = "Space";  // 动画触发器参数名

    private void Start()
    {
        // 开始时隐藏目标物件
        if (targetObject != null)
        {
            targetObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 检测是否是玩家接触触发器
        if (other.CompareTag("Player"))
        {
            // 显示目标物件
            if (targetObject != null)
            {
                targetObject.SetActive(true);
            }

            // 设置动画触发器，播放动画
            if (targetAnimator != null)
            {
                targetAnimator.SetTrigger(animationTriggerName);
            }
        }
    }
      
}