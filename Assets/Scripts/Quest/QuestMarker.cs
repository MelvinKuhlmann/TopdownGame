using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMarker : MonoBehaviour
{

    public string questToMark;
    public bool markComplete;
    public bool markOnEnter;
    private bool canMark;

    public bool deactivateOnMarking;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (canMark && Input.GetKeyDown(KeyCode.L))
        {
            canMark = false;
            MarkQuest();
        }
    }

    public void MarkQuest()
    {
        if (markComplete)
        {
            QuestManager.instance.MarkQuestComplete(questToMark);
        } else
        {
            QuestManager.instance.MarkQuestIncomplete(questToMark);
        }
        gameObject.SetActive(!deactivateOnMarking);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == Tag.Player.ToString())
        {
            if (markComplete)
            {
                MarkQuest();
            } else
            {
                canMark = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == Tag.Player.ToString())
        {
            canMark = false;
        }
    }
}
