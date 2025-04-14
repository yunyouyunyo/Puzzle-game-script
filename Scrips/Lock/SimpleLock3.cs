using UnityEngine;
using UnityEngine.UI;


public class SimpleLock3 : MonoBehaviour
{
    public bool Interactable = true;
    public GameObject LockCanvas;
    public Text[] Text;

    public string Password;
    public string[] LockCharacterChoices;
    public int[] _lockCharacterNumber;
    private string _insertedPassword;
    public Sprite UnlockSprite;
    public SpriteRenderer spriteRenderer;
    public GameObject Redlight;
    public GameObject Greenlight;
    void Start()
    {
        Greenlight.SetActive(false);
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        LockCanvas.SetActive(false);
        _lockCharacterNumber = new int[Password.Length];
        UpdateUI();
    }
    public void ChangeInsertedPassword(int number)
    {
        _lockCharacterNumber[number]++;
        if (_lockCharacterNumber[number] >= LockCharacterChoices[number].Length)
        {
            _lockCharacterNumber[number] = 0;
        }
        CheckPassword();
        UpdateUI();
    }
    public void CheckPassword()
    {
        int pass_len = Password.Length;
        _insertedPassword = "";
        for (int i = 0; i < pass_len; i++)
        {
            _insertedPassword += LockCharacterChoices[i][_lockCharacterNumber[i]].ToString();
        }
        if (Password == _insertedPassword)
        {
            Unlock();
        }
    }
    public void Unlock()
    {
        //Do Unlock thing
        spriteRenderer.sprite = UnlockSprite;
        spriteRenderer.size = new Vector2(3.0f, 3.0f);
        Debug.Log("Unlocked");
        Interactable = false;
        StopInteract();
        Greenlight.SetActive(true);
        Redlight.SetActive(false);
    }

    public void UpdateUI()
    {
        int len = Text.Length;
        for (int i = 0; i < len; i++)
        {
            Text[i].text = LockCharacterChoices[i][_lockCharacterNumber[i]].ToString();
        }
    }

    private void OnMouseDown()
    {
        Debug.Log("click");
        if (gameObject.CompareTag("Lock"))
        {
            Debug.Log("lock");
            Interact();
        }
        else
        {
            Debug.Log("unlock");
            StopInteract();
        }

    }


    
    private void OnMouseUp()
    {
        if (gameObject.CompareTag("Lock"))
        {
            Debug.Log("lock");
            Interact();
        }
        else
        {
            Debug.Log("unlock");
            StopInteract();
        }

    }
    public void Interact()
    {
        if (Interactable)
            LockCanvas.SetActive(true);
    }
    public void StopInteract()
    {
        LockCanvas.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("onTriggerEnter");
        }
    }
}

