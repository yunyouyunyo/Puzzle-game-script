using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toBig : MonoBehaviour
{
   public DynamicInventory dynamicInventory;
    public FixedInventoryItem fixedInventoryItem;
    public GameObject uiCanvas; // 用于显示的 UI Canvas

    private bool finish = false;
    private bool canShowUI = false; // 控制是否可以直接显示 UI Canvas

    public int index = 7;

    public NPC npc;                    // NPC 脚本的引用
    public string[] newDialogue;       // 对话内容数组
    public string[] nothingDialogue;

    void Start()
    {
        uiCanvas.SetActive(false); // 初始化时隐藏 UI Canvas
    }

    private void OnMouseDown()
    {
        // if (canShowUI)
        // {
        //     ShowUICanvas();
        //     return;
        // }

        Interact();

        if (finish)
        {
            Debug.Log("Interaction finished, activating other object and UI Canvas.");
            npc.SetDialogue(newDialogue);
            StartCoroutine(ShowDialogueSequence(newDialogue));
            finish = false;
            // canShowUI = true; // 标记可以直接显示 UI Canvas
            ShowUICanvas();
        }
        else
        {
            Debug.Log("Interaction not finished, other object remains inactive.");
        }
    }

    private IEnumerator ShowDialogueSequence(string[] dialogue)
    {
        npc.dialoguePanel.SetActive(true); // 确保对话框显示
        for (int i = 0; i < dialogue.Length; i++)
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
                // InventoryDisplay.Instance.DropItem(dynamicInventory.items[i].index);
                // dynamicInventory.RemoveItem(fixedInventoryItem);
                finish = true;
                Debug.Log("Item interaction complete, finish set to true.");
                break;
            }
        }
    }

    private void ShowUICanvas()
    {
        if (!uiCanvas.activeSelf)
        {
            Debug.Log("Showing UI Canvas.");
            uiCanvas.SetActive(true);
            StartCoroutine(HideUICanvasAfterDelay(3f));
        }
    }

    private IEnumerator HideUICanvasAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        uiCanvas.SetActive(false);
        Debug.Log("UI Canvas hidden after delay.");
    }
}
