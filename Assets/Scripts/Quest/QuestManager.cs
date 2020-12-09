using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public string[] questMarkerNames;
    public bool[] questMarkersComplete;

    public static QuestManager instance;

    void Start()
    {
        instance = this;

        questMarkersComplete = new bool[questMarkerNames.Length];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log(CheckIfComplete("quest test"));
            MarkQuestComplete("quest test");
        }
    }

    public int GetQuestIndex(string questName)
    {
        for (int i = 0; i < questMarkerNames.Length; i++)
        {
            if (questMarkerNames[i] == questName)
            {
                return i;
            }
        }

        Debug.LogError("Quest not found: '" + questName + "'");
        return -1;
    }

    public bool CheckIfComplete(string questName)
    {
        if (GetQuestIndex(questName) >= 0)
        {
            return questMarkersComplete[GetQuestIndex(questName)];
        }
        return false;
    }

    public void MarkQuestComplete(string questName)
    {
        if (GetQuestIndex(questName) >= 0)
        {
            questMarkersComplete[GetQuestIndex(questName)] = true;
            UpdateLocalQuestObjects();
        }
    }

    public void MarkQuestIncomplete(string questName)
    {
        if (GetQuestIndex(questName) >= 0)
        {
            questMarkersComplete[GetQuestIndex(questName)] = false;
            UpdateLocalQuestObjects();
        }
    }

    public void UpdateLocalQuestObjects()
    {
        QuestObjectActivator[] questObjects = FindObjectsOfType<QuestObjectActivator>();
        for (int i = 0; i < questObjects.Length; i++)
        {
            questObjects[i].CheckCompletion();
        }
    }
}
