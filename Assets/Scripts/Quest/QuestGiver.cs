using System.Collections.Generic;

public class QuestGiver : DialogActivator
{
    public List<Quest> availableQuests;

    public bool assignedQuest { get; set; }
    
    public bool helped { get; set; }

    public override void Interact()
    {
        AssignQuest(availableQuests[0]);

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
        QuestLog.instance.Add(quest);
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
