using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class QuestLogEntry : MonoBehaviour
{
    public Quest quest;
    public TMP_Text questName;

    void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(Press);
    }

    void Press()
    {
        QuestEvents.QuestClicked(quest);
    }

    public void AddQuest(Quest quest)
    {
        this.quest = quest;
        quest.Init();
        questName.enabled = true;
        questName.text = quest.name;
    }

    public void Clear()
    {
        quest = null;
        questName.enabled = false;
        questName.text = null;
    }
}
