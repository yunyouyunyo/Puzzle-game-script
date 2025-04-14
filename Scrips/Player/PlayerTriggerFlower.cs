using UnityEngine;

public class PlayerTriggerFlower : MonoBehaviour
{
    public GameObject targetObject;
    public Animator targetAnimator;    // 指向物件的 Animator 组件
    public bool Animdown = false;
    public string animationTriggerName = "Space";
  
    private void Start(){
        targetObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 检测是否是玩家接触触发器
        if (other.CompareTag("Player"))
        {
            // 显示目标物件
            if (targetObject != null && !Animdown )
            {
                targetObject.SetActive(true);
            }

            // 设置动画触发器，播放动画
            if (targetAnimator != null && !Animdown)
            {
                targetAnimator.SetTrigger(animationTriggerName);

            }
            Animdown = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        // 检测是否是玩家离开触发器
        if (other.CompareTag("Player"))
        {
            // 隐藏目标物件
            if (targetObject != null && Animdown)
            {
                targetObject.SetActive(false);
                Animdown = false;
            }
        }
    }
}
