using UnityEngine;

public class DialogActivator : MonoBehaviour
{

    [Header("Dialog")]
    public string[] lines;
    public bool isPerson = true;
    private bool canActivate;

    [Header("Quest")]
    public bool shouldActivateQuest;
    public string questToMark;
    public bool markComplete;


    void Update()
    {
        if (canActivate && Input.GetKeyDown(KeyCode.Return) && !DialogManager.instance.dialogBox.activeInHierarchy)
        {
            DialogManager.instance.ShowDialog(lines, isPerson);
            DialogManager.instance.ShouldActivateQuestAtEnd(questToMark, markComplete);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == Tag.Player.ToString())
        {
            canActivate = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == Tag.Player.ToString())
        {
            canActivate = false;
            if (DialogManager.instance.dialogBox.activeInHierarchy)
            {
                DialogManager.instance.dialogBox.SetActive(false);
            }
        }
    }
}
