using UnityEngine;
using System.Collections;

public class ItemControl : MonoBehaviour
{
    public DynamicInventory dynamicInventory; // 动态背包引用
    public FixedInventoryItem fixedInventoryItem; // 固定物品引用
    public GameObject otherObject; // 额外激活的对象

    public NPC npc; // NPC 脚本的引用
    public string[] newDialogue; // 玩家成功获得物品时的对话
    public string[] nothingDialogue; // 玩家未获得物品时的对话

    private bool finish = false; // 是否完成交互
    public int index; // 背包物品索引
    void Start()
    {
        // 初始化时将其他对象隐藏
        if (otherObject != null)
            otherObject.SetActive(false);

    }

    private void OnMouseDown()
    {
        Debug.Log("Mouse down detected.");
        // 检查是否获得物品
        Interact();

        if (finish)
        {
            // 获得物品，显示成功对话
            Debug.Log("Interaction finished, activating other object.");
            StartCoroutine(ShowDialogueSequence(newDialogue, true)); // 播放对话并激活
        }
        else
        {
            // 未获得物品，显示失败对话
            Debug.Log("Interaction not finished, other object remains inactive.");
            StartCoroutine(ShowDialogueSequence(nothingDialogue, false)); // 播放对话
        }
    }

    private IEnumerator ShowDialogueSequence(string[] dialogue, bool activateOtherObject)
    {
        if (dialogue == null || dialogue.Length == 0)
        {
            Debug.LogWarning("Dialogue is empty!");
            yield break; // 如果对话为空则直接退出
        }

        if (npc.dialoguePanel != null)
            npc.dialoguePanel.SetActive(true); // 显示对话框

        for (int i = 0; i < dialogue.Length; i++)
        {
            if (npc.dialogueText != null)
            {
                npc.index = i; // 设置当前显示的句子索引
                npc.dialogueText.text = dialogue[i]; // 显示对话内容
                Debug.Log($"Displaying dialogue {i}: {dialogue[i]}");
            }
            yield return new WaitForSeconds(1.5f); // 每句对话显示3.5秒
        }

        yield return new WaitForSeconds(0.2f); // 额外等待1秒
        if (npc != null)
        {
            npc.zeroText(); // 清空对话框内容
            if (npc.dialoguePanel != null)
                npc.dialoguePanel.SetActive(false); // 隐藏对话框
        }
        Debug.Log("Dialogue sequence completed.");

        // 如果激活标志为 true，激活其他对象并销毁当前物品
        if (activateOtherObject && otherObject != null)
        {
            otherObject.SetActive(true);
            if (gameObject.CompareTag("Buttle"))
            {
                Destroy(gameObject);

            }
        }
    }

    public void Interact()
    {
        Debug.Log("Attempting to get item.");
        finish = false; // 每次交互前重置为未完成状态

        if (dynamicInventory != null && dynamicInventory.items != null)
        {
            for (int i = 0; i < dynamicInventory.items.Count; i++)
            {
                // 如果找到与索引匹配的物品，且当前物品被选中
                if (dynamicInventory.items[i].index == index && InventoryDisplay.Instance.IsSelected(index))
                {
                    finish = true; // 完成交互
                    InventoryDisplay.Instance.DropItem(dynamicInventory.items[i].index); // 移除选中的物品
                    dynamicInventory.RemoveItem(fixedInventoryItem); // 从动态背包中移除物品
                    Debug.Log("Item interaction complete, finish set to true.");
                    break;
                }
            }
        }
        else
        {
            Debug.LogError("DynamicInventory or its items are not initialized!");
        }
    }

    public void StopInteract()
    {
        // 隐藏其他对象
        if (otherObject != null)
            otherObject.SetActive(false);
    }
}
