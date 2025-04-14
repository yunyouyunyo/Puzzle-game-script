using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public Text dialogueText;
    public string[] dialogue;
    public int index = 0;
    public bool playerIsClose;

    private void Start()
    {
        dialoguePanel.SetActive(false);
    }

    public void SetDialogue(string[] newDialogue)
    {
        dialogue = newDialogue;
        index = 0;
    }

    public void ShowDialogue()
    {
        if (index < dialogue.Length)
        {
            dialogueText.text = dialogue[index]; // 显示完整句子
            dialoguePanel.SetActive(true); // 确保对话框是开启的
        }
    }

    public void NextLine()
    {
        if (index < dialogue.Length -1 )
        {
            index++;
            dialogueText.text = dialogue[index]; // 显示下一行
        }
        else
        {
            zeroText(); // 结束对话时清空对话框
        }
    }

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
    }
}
