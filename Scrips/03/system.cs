using UnityEngine;

public class system : MonoBehaviour
{
    public DynamicInventory dynamicInventory;
    public FixedInventoryItem fixedInventoryItem;

    private void OnMouseDown()
    {
        Interact();
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
            else if (dynamicInventory.items[i].index == 7 && InventoryDisplay.Instance.IsSelected(7))
            {
                Debug.Log("Item interaction complete, finish set to true.");
                break;
            }
        }
    }
}