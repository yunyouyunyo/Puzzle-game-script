using Unity.VisualScripting;
using UnityEngine;


public class BoxTrigger : MonoBehaviour
{
    public GameObject othergameObject;
    
    public bool IsLocking = true;
    public GameObject Lock;
    private SpriteRenderer lockSpriteRenderer; // 用于控制颜色
    // private Collider2D lockCollider; // 用于控制碰撞


    void Start()
    {
        othergameObject.SetActive(false);
        
        lockSpriteRenderer = Lock.GetComponent<SpriteRenderer>();
        // lockCollider = Lock.GetComponent<Collider2D>();
        lockSpriteRenderer.color = Color.gray;
        // lockCollider.enabled = false; // 禁用 Collider2D

    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Box")
        {
            othergameObject.SetActive(true);
           
            gameObject.SetActive(false);
            
            IsLocking = false;
            lockSpriteRenderer.color = Color.white;
            // lockCollider.enabled = true; // 禁用 Collider2D
        }
    }
}