using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AcceptQuestManager : MonoBehaviour
{
    public static AcceptQuestManager instance;
    public GameObject acceptQuestPanel;
    public TMP_Text questName;
    public TMP_Text questDescription;
    public TMP_Text levelRequirement;
    public TMP_Text expReward;
    public TMP_Text shardsReward;
    public TMP_Text noOfQuests;
    public List<Quest> quests;

    private int currentQuestItem = 0;

    void Start()
    {
        instance = this;
    }

    public void SetQuests(List<Quest> questList)
    {
        quests = questList;
        if (quests.Count > 0)
        {
            currentQuestItem = 0;
            SetValues(quests[currentQuestItem]);
            acceptQuestPanel.SetActive(true);
        }
    }

    private void SetValues(Quest quest)
    {
        noOfQuests.text = (currentQuestItem + 1) + "/" + quests.Count;
        questName.text = quest.name;
        questDescription.text = quest.description;
        levelRequirement.text = quest.levelRequirement.ToString();
        expReward.text = quest.experienceReward.ToString();
        shardsReward.text = quest.shardsReward.ToString();
        //TODO add items to the Canvas
    }

    void Accept()
    {
        QuestLog.instance.Add(quests[currentQuestItem]);
        if (currentQuestItem < (quests.Count - 1))
        {
            currentQuestItem++;
            SetValues(quests[currentQuestItem]);
        }
        else
        {
            acceptQuestPanel.SetActive(false);
        }
    }

    void Decline()
    {
        if (currentQuestItem < (quests.Count - 1))
        {
            currentQuestItem++;
            SetValues(quests[currentQuestItem]);
        }
        else
        {
            acceptQuestPanel.SetActive(false);
        }
    }
}
