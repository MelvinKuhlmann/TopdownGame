using UnityEngine;
using UnityEngine.UI;

public class QuestLogEntry : MonoBehaviour
{
    public Quest quest;

    public Text questName;

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
