using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SimpleLock : MonoBehaviour
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
    public BoxTrigger boxTrigger;
    public NPC npc;
    public string[] newDialogue;
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

    public void OnMouseDown()
    {
        Debug.Log("click");
        if (gameObject.CompareTag("Lock") && !boxTrigger.IsLocking)
        {
            Debug.Log(boxTrigger.IsLocking);
            Debug.Log("lock");
            Interact();
        }
        else
        {
            Debug.Log("unlock");
            StopInteract();
            StartCoroutine(ShowDialogueSequence(newDialogue)); // 播放对话并激活
        }

    }

     private IEnumerator ShowDialogueSequence(string[] dialogue)
    {
        if (dialogue == null || dialogue.Length == 0)
        {
            Debug.LogWarning("Dialogue is empty!");
            yield break; // 如果对话为空则直接退出
        }

        if (npc.dialoguePanel != null)
            npc.dialoguePanel.SetActive(true); // 显示对话框

        for (int i = 0; i < dialogue.Length; i++)
        {
            if (npc.dialogueText != null)
            {
                npc.index = i; // 设置当前显示的句子索引
                npc.dialogueText.text = dialogue[i]; // 显示对话内容
                Debug.Log($"Displaying dialogue {i}: {dialogue[i]}");
            }
            yield return new WaitForSeconds(1.5f); // 每句对话显示3.5秒
        }

        yield return new WaitForSeconds(0.2f); // 额外等待1秒
        if (npc != null)
        {
            npc.zeroText(); // 清空对话框内容
            if (npc.dialoguePanel != null)
                npc.dialoguePanel.SetActive(false); // 隐藏对话框
        }
        Debug.Log("Dialogue sequence completed.");

    }
    private void OnMouseUp()
    {
        if (gameObject.CompareTag("Lock")&& !boxTrigger.IsLocking)
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

