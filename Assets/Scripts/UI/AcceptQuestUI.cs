using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AcceptQuestUI : MonoBehaviour
{
    [Header("UI elements")]
    public static AcceptQuestUI instance;
    public GameObject panel;
    public TMP_Text questName;
    public TMP_Text questDescription;
    public TMP_Text levelRequirement;
    public TMP_Text expReward;
    public TMP_Text shardsReward;
    public TMP_Text noOfQuests;
    public GameObject itemContainer;
    public List<Quest> quests;

    [Header("Item Prefab")]
    public GameObject itemPrefab;

    private int currentQuestItem = 0;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
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
        noOfQuests.text = (currentQuestItem + 1) + "/" + quests.Count;
        questName.text = quest.name;
        questDescription.text = quest.description;
        levelRequirement.text = quest.levelRequirement.ToString();
        expReward.text = quest.experienceReward.ToString();
        shardsReward.text = quest.shardsReward.ToString();

        //Clear before filling
        foreach (Transform child in itemContainer.transform)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < quest.itemRewards.Count; i++)
        {
            GameObject item = Instantiate(itemPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            item.transform.SetParent(itemContainer.transform, false);

            ItemButton itemButton = item.GetComponent<ItemButton>();
            itemButton.itemImage.sprite = quest.itemRewards[i].icon;
            itemButton.amountText.text = "";
            itemButton.item = quest.itemRewards[i];
        }
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
            panel.SetActive(false);
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
            panel.SetActive(false);
        }
    }
}
