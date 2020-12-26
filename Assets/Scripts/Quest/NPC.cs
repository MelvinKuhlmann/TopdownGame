using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    public int ID;
    [Header("Quest")]
    public List<Quest> availableQuests;
    public bool assignedQuest { get; set; }
    public bool helped { get; set; }

    public override void Talk()
    {
        base.Talk();
        NPCEvents.OnNPCInteracted(this);
    }

    public void Quests()
    {
        List<Quest> questsToAccept = new List<Quest>();

        availableQuests.ForEach(currentQuest => {
            if (!QuestLog.instance.AlreadyAccepted(currentQuest)) {
                questsToAccept.Add(currentQuest);
            } else
            {
                CheckQuest(currentQuest);
            }
        });

        AcceptQuestManager.instance.SetQuests(questsToAccept);
        assignedQuest = true;
    }

    void CheckQuest(Quest quest)
    {
        if (quest.completed)
        {
            quest.GiveReward();
            helped = true;
            assignedQuest = false;
            QuestLog.instance.Remove(quest);
        }
    }
}
