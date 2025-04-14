using UnityEngine;
using System.Collections;

public class AutoDialogueTrigger : MonoBehaviour
{
    public NPC npc;                    // NPC 脚本的引用
    public string[] newDialogue;       // 对话内容数组
    private bool triggered = false;    // 确保触发只发生一次

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player") && !triggered)
        {
            triggered = true;
            npc.SetDialogue(newDialogue);
            StartCoroutine(ShowDialogueSequence());
        }
    }

    private IEnumerator ShowDialogueSequence()
    {
        npc.dialoguePanel.SetActive(true); // 确保对话框显示
        for (int i = 0; i < newDialogue.Length; i++)
        {
            npc.index = i; // 设置当前显示的句子索引
            npc.dialogueText.text = newDialogue[i]; // 直接显示当前句子
            yield return new WaitForSeconds(1.5f); // 等待2秒显示时间
        }
        
        // 完成后关闭对话框
        npc.zeroText();
    }

}
