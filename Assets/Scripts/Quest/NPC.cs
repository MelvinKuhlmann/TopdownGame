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
        if (assignedQuest)
        {
            QuestRewards();
        }
        if (!AcceptRewardManager.instance.IsActive())
        {

            List<Quest> questsToAccept = new List<Quest>();

            availableQuests.ForEach(currentQuest =>
            {
                if (!QuestLog.instance.AlreadyAccepted(currentQuest))
                {
                    questsToAccept.Add(currentQuest);
                }
            });

            AcceptQuestManager.instance.SetQuests(questsToAccept);
            assignedQuest = true;
        }
    }

    public void QuestRewards()
    {
        List<Quest> completedQuests = new List<Quest>();

        availableQuests.ForEach(currentQuest => {
            if (QuestLog.instance.QuestCompleted(currentQuest))
            {
                completedQuests.Add(currentQuest);
            }
        });

        AcceptRewardManager.instance.SetQuests(completedQuests);
    }
}
