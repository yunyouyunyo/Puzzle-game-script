using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Serialized
[CreateAssetMenu]
public class DynamicInventory : ScriptableObject
{
    public int maxItems = 12; 
    //static list
    public List<FixedInventoryItem> items = new();
    

    public bool AddItem(FixedInventoryItem itemToAdd)
    {
        // Finds an empty slot if there is one
        for (int i = 0; i < items.Count; i++)
        {
            Debug.Log("AddItem");
            if (items[i] == null)
            {
                items[i] = itemToAdd;
                return true;
            }
        }

        // Adds a new item if the inventory has space
        if (items.Count < maxItems)
        {
            items.Add(itemToAdd);
            return true;
        }

        Debug.Log("No space in the inventory");
        return false;
    }
    public void RemoveItem(FixedInventoryItem itemToRemove)
    {
        items.Remove(itemToRemove);
        Debug.Log("RemoveItem");
        Debug.Log(items.Count);
    }
}
