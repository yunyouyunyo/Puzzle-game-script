using UnityEngine;

public class KeyPressDialogueTrigger : MonoBehaviour
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

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            playerIsClose = true; // 标记玩家靠近
            npc.SetDialogue(newDialogue); // 设置对话内容
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.CompareTag("Player"))
        {
            playerIsClose = false; // 标记玩家离开
            npc.zeroText(); // 清空对话框
        }
    }
}
