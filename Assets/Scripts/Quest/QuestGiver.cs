using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
   /* public Quest quest;

    public PlayerController player;

    // continue: https://www.youtube.com/watch?v=e7VEe_qW4oE 14:54*/


    public bool assignedQuest { get; set; }
    public bool helped { get; set; }
    
    [SerializeField]
    private GameObject quests;

    [SerializeField]
    private string questType;
    private Quest quest { get; set; }

    public void Interact()
    {
        if (!assignedQuest && !helped)
        {
            AssignQuest();
        }
        else if (assignedQuest && !helped)
        {
            // check
        }
        else
        {

        }
    }

    void AssignQuest()
    {
        assignedQuest = true;
        quest = (Quest)quests.AddComponent(System.Type.GetType(questType));

    }

    void CheckQuest()
    {
        if (quest.completed)
        {
            quest.GiveReward();
            helped = true;
            assignedQuest = false;
        }
    }
}
