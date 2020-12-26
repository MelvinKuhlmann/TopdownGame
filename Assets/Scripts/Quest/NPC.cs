using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class NPC : Interactable
{
    [Header("NPC")]
    public int ID;
    public string npcName = string.Empty;
    [Header("Quest")]
    public List<Quest> availableQuests;
    public bool assignedQuest { get; set; }
    public bool helped { get; set; }

    private NpcCanvas canvas;
    private void Awake()
    {
        if (npcName.Equals(""))
        {
            Debug.LogWarning("npcName is not filled, fallback to 'NPC'");
            npcName = "NPC";
        }
        canvas = GetComponentInChildren<NpcCanvas>();
        canvas.SetNpcName(npcName);
        canvas.SetQuestIconVisible(availableQuests.Count > 0);
        canvas.SetQuestIconToNewQuest();
    }

    public override void UpdateHook()
    {
        if (!GetComponent<Renderer>().isVisible)
        {
            //NPC is not shown by camera
            return;
        }
        if (ShowQuestCompleteIcon())
        {
            canvas.SetQuestIconToQuestComplete();
        }
        else
        {
            canvas.SetQuestIconToNewQuest();
        }
    }

    private bool ShowQuestCompleteIcon()
    {
        return availableQuests.Any(currentQuest => QuestLog.instance.QuestCompleted(currentQuest));
    }

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
