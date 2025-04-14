using UnityEngine;
using System.Collections;

public class imageControll : MonoBehaviour
{
    public DynamicInventory dynamicInventory;
    public FixedInventoryItem fixedInventoryItem;
    public GameObject otherObject;


    public NPC npc;                    // NPC 脚本的引用
    public string[] newDialogue;       // 对话内容数组

    private bool finish = false;
    public int index = 6;

    void Start()
    {
        otherObject.SetActive(false);


    }

    private void OnMouseDown()
    {
        Debug.Log("Mouse down detected.");
        Interact();

        if (finish)
        {
            Debug.Log("Interaction finished, activating other object.");
            npc.SetDialogue(newDialogue);
            StartCoroutine(ShowDialogueSequence());
            otherObject.SetActive(true);
            Destroy(gameObject);
            finish = false;
        }
        else
        {
            Debug.Log("Interaction not finished, other object remains inactive.");
        }
    }

    private IEnumerator ShowDialogueSequence()
    {
        npc.dialoguePanel.SetActive(true); // 确保对话框显示
        for (int i = 0; i < newDialogue.Length; i++)
        {
            npc.index = i; // 设置当前显示的句子索引
            npc.dialogueText.text = newDialogue[i]; // 直接显示当前句子
            yield return new WaitForSeconds(2f); // 等待2秒显示时间
        }

        // 完成后关闭对话框
        npc.zeroText();
    }

    public void Interact()
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
}

