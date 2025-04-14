using UnityEngine;
using UnityEngine.SceneManagement;


public class PortalKey : MonoBehaviour
{
    public string SceneName;
    public DynamicInventory dynamicInventory;
    public FixedInventoryItem fixedInventoryItem;
    private bool finish = false;
    public int index = 2;
    void Start()
    {
        this.transform.tag = "Portal";
    }
    private void OnMouseDown()
    {
        Interact();

        if (finish)
        {
            ChangeScene();
            Debug.Log("Interaction finished, activating other object.");
            finish = false;
        }
        else
        {
            Debug.Log("Interaction not finished, other object remains inactive.");
        }
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
    public void ChangeScene()
    {
        print("change");
        SceneManager.LoadScene(SceneName);
    }
}
