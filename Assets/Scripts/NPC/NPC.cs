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
            npcName = "NPC";
        }
        canvas = GetComponentInChildren<NpcCanvas>();
        canvas.SetNpcName(npcName);
        canvas.SetQuestIconVisible(availableQuests.Count > 0);
        canvas.SetQuestIconToNewQuest();
    }

    public override void UpdateHook()
    {
        Moving();
        if (!GetComponent<Renderer>().isVisible)
        {
            //NPC is not shown by camera
            return;
        }
        if (ShowQuestCompleteIcon())
        {
            //Show quest complete icon when at least one quest of this questgiver is ready to turn in
            canvas.SetQuestIconVisible(true);
            canvas.SetQuestIconToQuestComplete();
        }
        else if (availableQuests.Any(currentQuest => !QuestLog.instance.AlreadyAccepted(currentQuest)))
        {
            //Show quest available icon only when at least one quest can be accepted
            canvas.SetQuestIconVisible(true);
            canvas.SetQuestIconToNewQuest();
        } else
        {
            //Hide the icon if nothing can be turned in, and no quests can be accepted
            canvas.SetQuestIconVisible(false);
        }
    }

    private void Moving()
    {
        FollowPath path = GetComponent<FollowPath>();
        if (path == null)
        {
            return;
        }
       
        if(path.MoveHorizontal() == 0 && path.MoveVertical()  == 0)
        {
            ChangeAnimation("isIdle");
        }

        if (path.MoveHorizontal() > 0)
        {
            ChangeAnimation("isMovingRight");
        } else
        {
            ChangeAnimation("isMovingLeft");
        }
        if (path.MoveVertical() > 0)
        {
            ChangeAnimation("isMovingUp");
        }
        else
        {
            ChangeAnimation("isMovingDown");
        }
    }

    public void ChangeAnimation(string animationFlag, bool resetAll = true)
    {
        if (resetAll)
        {
            ResetAnimationParameters();
        }
        GetComponent<Animator>().SetBool(animationFlag, true);
    }

    private void ResetAnimationParameters()
    {
        foreach (AnimatorControllerParameter parameter in GetComponent<Animator>().parameters)
        {
            GetComponent<Animator>().SetBool(parameter.name, false);
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
        if (!AcceptRewardUI.instance.IsActive())
        {

            List<Quest> questsToAccept = new List<Quest>();

            availableQuests.ForEach(currentQuest =>
            {
                if (!QuestLog.instance.AlreadyAccepted(currentQuest))
                {
                    questsToAccept.Add(currentQuest);
                }
            });

            AcceptQuestUI.instance.SetQuests(questsToAccept);
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

        AcceptRewardUI.instance.SetQuests(completedQuests);
    }
}
