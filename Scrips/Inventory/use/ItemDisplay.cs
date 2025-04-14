using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ItemDisplay : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public static ItemDisplay selectedItem;
    public int itemIndex;
    public Image image;
    public Color normalColor;
    public Color highlightedColor = Color.blue;
    public Color pressColor = Color.red;
    public bool isSelected = false;
    
    public void UpdateItemDisplay(Sprite newImage, int newItemIndex)
    {

        Debug.Log("UpdateItem");
        image.sprite = newImage;
        itemIndex = newItemIndex;
    }

    public void DropFromInventory(Sprite block)
    {
        image.sprite = block;
        Debug.Log("Drop finish");
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (selectedItem != null && selectedItem != this)
        {
            selectedItem.Deselect();
        }

        if (!isSelected)
        {
            Select();

        }
        else
        {
            Deselect();
        }
    }
    public void Select()
    {
        isSelected = true;
        selectedItem = this;
        image.color = pressColor;
    }
    public void Deselect()
    {
        isSelected = false;
        selectedItem = null;
        image.color = normalColor;

    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!isSelected)
        {
            image.color = highlightedColor;
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isSelected)
        {
            image.color = normalColor;
        }

    }

}
