using System.Collections;
using UnityEngine;

public class InstanceItemContainer : MonoBehaviour
{
    public DynamicInventory dynamicInventory; // 动态背包引用
    public FixedInventoryItem item;          // 当前物品
    public NPC npc;                          // NPC 脚本
    public string text;                      // 对话内容
    public float dialogueDisplayTime = 2.0f; // 对话框显示时间

    private Collider2D itemCollider;         // 缓存 Collider
    private Renderer itemRenderer;           // 缓存 Renderer

    private void Start()
    {
        // 缓存 Collider 和 Renderer
        itemCollider = GetComponent<Collider2D>();
        itemRenderer = GetComponent<Renderer>();

        if (npc == null || dynamicInventory == null)
        {
            Debug.LogError("Missing required references! Ensure NPC and DynamicInventory are assigned.");
            enabled = false;
        }

        npc.dialoguePanel.SetActive(false); // 初始化对话框隐藏
    }

    private void OnMouseDown()
    {
        if (itemCollider != null) itemCollider.enabled = false; // 禁用点击
        if (itemRenderer != null) itemRenderer.enabled = false; // 隐藏物品

        if (dynamicInventory.AddItem(item)) // 添加物品到动态背包
        {
            InventoryDisplay.Instance.UpdateInventory();
            npc.dialoguePanel.SetActive(true); // 显示对话框
            npc.dialogueText.text = text;

            StartCoroutine(DisableDialogueAndDestroy()); // 开始协程
        }
        else
        {
            Debug.LogWarning("Failed to add item to inventory.");
        }
    }

    private IEnumerator DisableDialogueAndDestroy()
    {
        yield return new WaitForSeconds(dialogueDisplayTime); // 等待对话框显示
        npc.dialoguePanel.SetActive(false);                  // 隐藏对话框
        Destroy(gameObject);                                 // 销毁物体
    }
}
