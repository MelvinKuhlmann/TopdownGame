using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : DialogActivator
{
    public List<Quest> availableQuests;

    public bool assignedQuest { get; set; }
    
    public bool helped { get; set; }

    public override void Interact()
    {
        if (!assignedQuest && !helped)
        {
            AssignQuest(availableQuests[0]);
        }
        else if (assignedQuest && !helped)
        {
            // check
            CheckQuest(availableQuests[0]);
        }
        else
        {
          
        }
    }

    void AssignQuest(Quest quest)
    {
        QuestLog.instance.Add(quest);
        assignedQuest = true;
    }

    void CheckQuest(Quest quest)
    {
        if (quest.completed)
        {
            Debug.Log("quest reward");
            quest.GiveReward();
            helped = true;
            assignedQuest = false;
            DialogManager.instance.dialogLines = new string[]{ "thank you"};
            QuestLog.instance.Remove(quest);
        } else
        {
            Debug.Log("quest not completed yet: " + availableQuests[0].name);
        }
    }
}
