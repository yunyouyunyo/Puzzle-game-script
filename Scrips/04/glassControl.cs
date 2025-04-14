using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glassControl : MonoBehaviour
{
    public Animator animator;
    private bool hasPlayed = false; // 確保動畫只播放一次

    void Start()
    {
        // 取得 Animator 組件
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("物件缺少 Animator 組件！");
        }
        animator.enabled = false;
    }

    private void OnMouseDown()
    {
        // 確保動畫只播放一次
        if (!hasPlayed) // 假設 "Player" 是玩家的 Tag
        {
        hasPlayed = true;
           animator.enabled = true;
           animator.SetTrigger("Play");
        }
    }
}

