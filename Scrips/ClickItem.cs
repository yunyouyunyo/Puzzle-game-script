using System.Collections;
using UnityEngine;

public class ClickItem : MonoBehaviour
{
    public GameObject item;
    public void Start()
    {
        item.SetActive(false);
    }

    private void OnMouseDown()
    {

        if (gameObject.CompareTag("suitcase"))
        {
            Destroy(gameObject);
        }
        Debug.Log("Object clicked!");
        // gameObject.SetActive(false);
        item.SetActive(true);
    }



}
