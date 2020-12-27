using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AcceptRewardUI : MonoBehaviour
{
    public static AcceptRewardUI instance;
    public GameObject panel;
    public TMP_Text questName;
    public TMP_Text questCompletionDescription;
    public TMP_Text expReward;
    public TMP_Text shardsReward;
    public List<Quest> quests;

    private int currentQuestItem = 0;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public bool IsActive()
    {
        return panel.activeInHierarchy;
    }

    public void SetQuests(List<Quest> questList)
    {
        quests = questList;
        if (quests.Count > 0)
        {
            currentQuestItem = 0;
            SetValues(quests[currentQuestItem]);
            panel.SetActive(true);
        }
    }

    private void SetValues(Quest quest)
    {
        questName.text = quest.name;
        questCompletionDescription.text = quest.completedDescription;
        expReward.text = quest.experienceReward.ToString();
        shardsReward.text = quest.shardsReward.ToString();
        //TODO add items to the Canvas
    }

    void AcceptReward()
    {
        if (quests[currentQuestItem].completed)
        {
            quests[currentQuestItem].GiveReward();
            QuestLog.instance.Remove(quests[currentQuestItem]);
        }
        if (currentQuestItem < (quests.Count - 1))
        {
            currentQuestItem++;
            SetValues(quests[currentQuestItem]);
        }
        else
        {
            panel.SetActive(false);
        }
    }
}
