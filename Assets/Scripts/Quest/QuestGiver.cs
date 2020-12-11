using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : DialogActivator
{
    [Header("Quest")]
    public List<Quest> quests;

    public QuestList questList;

    public bool assignedQuest { get; set; }
    
    public bool helped { get; set; }

    public override void Interact()
    {
        AssignQuest(quests[0]);

        if (!assignedQuest && !helped)
        {
            // AssignQuest();
        }
        else if (assignedQuest && !helped)
        {
            // check
        }
        else
        {

        }
    }

    void AssignQuest(Quest quest)
    {
        quests.Add(quest);
        Debug.Log("quest received: " + quest.questName);
    }

    void CheckQuest(Quest quest)
    {
        if (quest.completed)
        {
            quest.GiveReward();
            helped = true;
            assignedQuest = false;
            DialogManager.instance.dialogLines = new string[]{ "thank you"};
        }
    }
}
