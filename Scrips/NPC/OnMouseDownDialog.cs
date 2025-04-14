using UnityEngine;

public class OnMouseDownDialog : MonoBehaviour
{
    public bool playerIsClose;          // 玩家是否靠近触发器
    public NPC npc;                     // NPC 脚本的引用
    public string[] newDialogue;        // 对话内容数组


    void Update()
    {
        // 如果玩家按下空格键且靠近 NPC
        if (Input.GetKeyDown(KeyCode.Space) && playerIsClose)
        {
            if (!npc.dialoguePanel.activeInHierarchy)
            {
                npc.ShowDialogue(); // 显示当前对话
            }
            else
            {
                npc.NextLine(); // 显示下一行对话
            }
        }
    }

    public void OnMouseDown()
    {
        if (!npc.dialoguePanel.activeInHierarchy)
        {
            npc.SetDialogue(newDialogue);
            npc.ShowDialogue(); // 显示当前对话 
            StartCoroutine(AutoHideDialogue()); // 启动协程自动隐藏对话框


        }
        else
        {
            npc.NextLine(); // 显示下一行对话
        }

    }

    private System.Collections.IEnumerator AutoHideDialogue()
    {
        yield return new WaitForSeconds(2f); // 等待 2 秒
        npc.zeroText(); // 调用方法清空对话框
    }
}
