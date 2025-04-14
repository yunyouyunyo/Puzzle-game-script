using UnityEngine;
using UnityEngine.UI;

public class bariconControll : MonoBehaviour
{
    public Image image;
    public Text text;
    private RectTransform rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        image.enabled = false;
        text.enabled = false;
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        Vector2 mousePos = Input.mousePosition;
        if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, mousePos))
        {
            image.enabled = true;
            text.enabled = true;
        }
        else
        {
            image.enabled = false;
            text.enabled = false;
        }
    }
    // void OnMouseEnter()
    // {
    //     image.enabled = true;
    //     text.enabled = true;
    // }

    // void OnMouseExit()
    // {
    //     image.enabled = false;
    //     text.enabled = false;
    // }

}
