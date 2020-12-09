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
    private bool justStarted;

    private string questToMark;
    private bool markQuestComplete;
    private bool shouldMarkQuest;

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if (dialogBox.activeInHierarchy)
        {
            if (Input.GetKeyUp(KeyCode.Return))
            {
                if (!justStarted)
                {
                    currentLine++;
                    if (currentLine >= dialogLines.Length)
                    {
                        dialogBox.SetActive(false);

                        if (shouldMarkQuest)
                        {
                            shouldMarkQuest = false;
                            if (markQuestComplete)
                            {
                                QuestManager.instance.MarkQuestComplete(questToMark);
                            } else
                            {
                                QuestManager.instance.MarkQuestIncomplete(questToMark);
                            }
                        }
                    } else {
                        CheckIfName();
                        dialogText.text = dialogLines[currentLine];
                    }
                } else
                {
                    justStarted = false;
                }
            }
        }
    }

    public void ShowDialog(string[] newLines, bool isPerson)
    {
        dialogLines = newLines;
        currentLine = 0;
        CheckIfName();
        dialogText.text = dialogLines[currentLine];
        dialogBox.SetActive(true);
        justStarted = true;
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

    public void ShouldActivateQuestAtEnd(string questName, bool markComplete)
    {
        questToMark = questName;
        markQuestComplete = markComplete;

        shouldMarkQuest = true;
    }
}