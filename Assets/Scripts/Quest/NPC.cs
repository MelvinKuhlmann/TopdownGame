using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    public int ID;

    [Header("Quest")]
    public List<Quest> availableQuests;
    public string[] questLines;
    public string[] questNotCompletedLines;
    public string[] questRewardLines;

    public bool assignedQuest { get; set; }
    
    public bool helped { get; set; }

    public override void Interact()
    {
        if (!assignedQuest && !helped)
        {
            if (availableQuests != null && availableQuests.Count >= 1)
            {
                if (!DialogManager.instance.dialogBox.activeInHierarchy)
                {
                    DialogManager.instance.ShowDialog(questLines, isPerson);
                }
                AssignQuest(availableQuests[0]);
            } else
            {
                base.Interact();
            }
        }
        else if (assignedQuest && !helped)
        {
            // check
            CheckQuest(availableQuests[0]);
        }
        NPCEvents.OnNPCInteracted(this);
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
            if (!DialogManager.instance.dialogBox.activeInHierarchy)
            {
                DialogManager.instance.ShowDialog(questRewardLines, isPerson);
            }
            quest.GiveReward();
            helped = true;
            assignedQuest = false;
            QuestLog.instance.Remove(quest);
        } else
        {
            Debug.Log("quest not completed yet: " + availableQuests[0].name);
            if (!DialogManager.instance.dialogBox.activeInHierarchy)
            {
                DialogManager.instance.ShowDialog(questNotCompletedLines, isPerson);
            }
        }
    }
}
