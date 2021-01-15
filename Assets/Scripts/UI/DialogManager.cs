using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public TMP_Text dialogText;
    public TMP_Text nameText;
    public GameObject dialogBox;
    public GameObject nameBox;

    public string[] dialogLines;

    public int currentLine = 0;

    public static DialogManager instance;

    void Start()
    {
        instance = this;
    }

    public bool IsActive()
    {
        return dialogBox.activeInHierarchy;
    }

    public void Nextline()
    {
        currentLine++;
        if (currentLine >= dialogLines.Length)
        {
            dialogBox.SetActive(false);
        }
        else
        {
            CheckIfName();
            dialogText.text = dialogLines[currentLine];
        }
    }

    public void ShowDialog(string[] newLines, bool isPerson)
    {
        dialogLines = newLines;
        currentLine = 0;
        CheckIfName();
        dialogText.text = dialogLines[currentLine];
        dialogBox.SetActive(true);
        nameBox.SetActive(isPerson);
    }

    public void CheckIfName()
    {
        if (dialogLines[currentLine].StartsWith("n-"))
        {
            nameText.text = dialogLines[currentLine].Replace("n-", "");
            currentLine++;
        }
    }
}