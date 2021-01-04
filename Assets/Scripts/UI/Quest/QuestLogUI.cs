using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class QuestLogUI : MonoBehaviour
{
    [Header("UI Objects")]
    public GameObject panel;
    public GameObject questList;
    public GameObject questObjectiveList;
    public List<QuestLogEntry> questLogEntries;

    [Header("Item Prefabs")]
    public GameObject questEntry;
    public GameObject questObjective;

    [Header("UI Quest Information")]
    public TMP_Text questName;
    public TMP_Text questDescription;

    private QuestLog questLog;

    #region Singleton
    public static QuestLogUI instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of QuestLogUI found");
            return;
        }

        instance = this;
        questLog = QuestLog.instance;
        questLog.onQuestChangedCallback += UpdateUI;
        QuestEvents.OnQuestClicked += QuestClicked;
    }
    #endregion

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (panel.activeInHierarchy)
            {
                panel.SetActive(false);
            } else
            {
                panel.SetActive(true);
                UpdateUI();
            }
        }
    }

    void UpdateUI()
    {
        ClearList(questList.transform);

        for (int i = 0; i < questLog.currentQuests.Count; i++)
        {
            GameObject entry = Instantiate(questEntry, new Vector3(0, 0, 0), Quaternion.identity);
            entry.transform.SetParent(questList.transform, false);

            QuestLogEntry questButton = entry.GetComponent<QuestLogEntry>();
            questButton.AddQuest(questLog.currentQuests[i]);
        }

        if (questLog.currentQuests.Count > 0)
        {
            SetInformation(questLog.currentQuests[0]);
        }
    }

    void ClearList(Transform parent)
    {
        foreach (Transform child in parent)
        {
            Destroy(child.gameObject);
        }
    }

    void SetInformation(Quest quest)
    {
        questName.text = quest.name;
        questDescription.text = quest.description;

        ClearList(questObjectiveList.transform);

        for (int i = 0; i < quest.goals.Count; i++)
        {
            GameObject entry = Instantiate(questObjective, new Vector3(0, 0, 0), Quaternion.identity);
            entry.transform.SetParent(questObjectiveList.transform, false);

            QuestObjectiveEntry objective = entry.GetComponent<QuestObjectiveEntry>();
            objective.objectiveTitle.text = quest.goals[i].description;
        }
    }

    void QuestClicked(Quest quest)
    {
        SetInformation(quest);
    }
}
