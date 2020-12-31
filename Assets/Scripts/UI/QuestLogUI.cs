using UnityEngine;

public class QuestLogUI : ToggleableUI
{
    private QuestLog questLog;
    public QuestLogEntry[] questLogEntries;

    public void Start()
    {
        questLog = QuestLog.instance;
        questLog.onQuestChangedCallback += UpdateUI;
        canvasGroup = GetComponent<CanvasGroup>();

        Hide();
        UpdateUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (canvasGroup.alpha == 1)
            {
                Hide();
            }
            else
            {
                Show();
            }
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
