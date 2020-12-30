using UnityEngine;

public class QuestLogUI : CloseUI
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
            canvasGroup = GetComponent<CanvasGroup>();
            if (canvasGroup.alpha == 1)
            {
                Hide();
                Debug.Log("PrintOnEnable: Questlog was turned invisible");
            }
            else
            {
                Show();
                Debug.Log("PrintOnEnable: Questlog was turned visible");
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
