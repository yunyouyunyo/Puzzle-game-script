using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class InventoryDisplay : MonoBehaviour
{

    public DynamicInventory dynamicInventory;
    public ItemDisplay[] slots = new ItemDisplay [12];
    public Sprite nullBlock;
    public FixedInventoryItem selectedItem;

    public static InventoryDisplay Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    //temp
    private void Start()
    {
        dynamicInventory.items.Clear();
        // UpdateInventory();
    }

    public void UpdateInventory()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            Debug.Log("Enter loop");
            if (i < dynamicInventory.items.Count)
            {
                Debug.Log("get inventory");
                // slots[i].gameObject.SetActive(true); 
                slots[i].UpdateItemDisplay(dynamicInventory.items[i].icon, dynamicInventory.items[i].index);
            }
            else
            {
                // slots[i].gameObject.SetActive(false);
                Debug.Log("Not get inventory");

            }
        }
        Debug.Log("Not do anything");
    }

    public void DropItem(int dropItemIndex)
    {
        for (int i = 0; i < 12; i++)
        {
            if (slots[i].itemIndex == dropItemIndex)
            {
                Debug.Log("CheckDropItem");
                slots[i].DropFromInventory(nullBlock);
                slots[i].Deselect();
                break;

            }
        }
        // UpdateInventory();
    }
    public bool IsSelected(int index)
    {
        int num = 8;
        for (int i = 0; i < 12; i++)
        {
            Debug.Log(index);
            if (slots[i].itemIndex == index)
            {
                num = i;
                Debug.Log("num");
                Debug.Log(num);
                break;
            }
        }
        return slots[num].isSelected;

    }

  


}
