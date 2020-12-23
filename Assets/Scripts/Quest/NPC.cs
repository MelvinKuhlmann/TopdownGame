﻿using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    public int ID;

    [Header("Quest")]
    public List<Quest> availableQuests;

    public bool assignedQuest { get; set; }
    
    public bool helped { get; set; }

    private bool uiActivated = false;

    private void Update()
    {
        if (canActivate && !NpcInteractionController.instance.IsActive() && !uiActivated)
        {
            NpcInteractionController.instance.SetNPC(this);
            uiActivated = true;
        } else if (!canActivate && NpcInteractionController.instance.IsActive() && uiActivated)
        {
            NpcInteractionController.instance.RemoveNPC();
            uiActivated = false;
        }
    }

    public void Talk()
    {
        base.Interact();
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
