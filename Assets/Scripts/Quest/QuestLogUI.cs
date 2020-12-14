﻿using UnityEngine;

public class QuestLogUI : MonoBehaviour
{
    private QuestLog questLog;
    public QuestLogEntry[] questLogEntries;

    public void Start()
    {
        questLog = QuestLog.instance;
        questLog.onQuestChangedCallback += UpdateUI;

        UpdateUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            gameObject.SetActive(!gameObject.activeInHierarchy);
        }
    }

    void UpdateUI()
    {
        questLogEntries = transform.GetComponentsInChildren<QuestLogEntry>();

        for (int i = 0; i < questLog.currentQuests.Count; i++)
        {
            questLogEntries[i].Clear();
            questLogEntries[i].AddQuest(questLog.currentQuests[i]);
        }
    }
}