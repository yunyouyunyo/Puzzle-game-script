using UnityEngine;
using System.Collections;

public class FlowerControl : MonoBehaviour
{
    public DynamicInventory dynamicInventory;
    public FixedInventoryItem fixedInventoryItem;
    public GameObject otherObject;
    private bool finish = false;
    public int index = 1;

    public NPC npc;                    // NPC 脚本的引用
    public string[] newDialogue;       // 对话内容数组
    public string[] nothingDialogue;
    void Start()
    {
        otherObject.SetActive(false);
    }

    private void OnMouseDown()
    {
        Interact();

        if (finish)
        {
            Debug.Log("Interaction finished, activating other object.");
            npc.SetDialogue(newDialogue);
            StartCoroutine(ShowDialogueSequence(newDialogue));
            otherObject.SetActive(true); // 仅在 finish 为 true 时激活
            finish = false;
        }
        else
        {
            Debug.Log("Interaction not finished, other object remains inactive.");
        }
    }

    private IEnumerator ShowDialogueSequence(string[]dialogue)
    {
        npc.dialoguePanel.SetActive(true); // 确保对话框显示
        for (int i = 0; i < dialogue.Length+1; i++)
        {
            npc.index = i; // 设置当前显示的句子索引
            npc.dialogueText.text = dialogue[i]; // 直接显示当前句子
            yield return new WaitForSeconds(2f); // 等待2秒显示时间
        }

        // 完成后关闭对话框
        npc.zeroText();
    }

    private void Interact()
    {
        Debug.Log("Attempting to get item.");

        for (int i = 0; i < dynamicInventory.items.Count; i++)
        {
            if (dynamicInventory.items == null)
            {
                Debug.LogError("dynamicInventory.items is not initialized!");
                return;
            }
            else if (dynamicInventory.items[i].index == index && InventoryDisplay.Instance.IsSelected(index))
            {
                InventoryDisplay.Instance.DropItem(dynamicInventory.items[i].index);
                dynamicInventory.RemoveItem(fixedInventoryItem);
                finish = true;
                Debug.Log("Item interaction complete, finish set to true.");
                break;
            }
            
        }
    }
    public void StopInteract()
    {
        otherObject.SetActive(false);
    }

}


