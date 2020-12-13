using System.Collections.Generic;
using UnityEngine;

public class QuestLog : MonoBehaviour
{
    #region Singleton

    public static QuestLog instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of QuestList found");
            return;
        }

        instance = this;
    }
    #endregion

    public List<Quest> currentQuests;
    public int maxAmountOfQuests = 7;

    // Callback which is triggered when
    // a quest gets added/removed.
    public delegate void OnQuestChanged();
    public OnQuestChanged onQuestChangedCallback;

    // This method returns true if a quest is succesfully added, false otherwise.
    public bool Add(Quest quest)
    {
        if (currentQuests.Count >= maxAmountOfQuests)
        {
            Debug.Log("Can't add more quests!");
            return false;
        }

        if (currentQuests.Find(currentQuest => currentQuest.name.Equals(quest.name)) != null)
        {
            Debug.Log("Quest already exists in quest log!");
            return false;
        }

        Debug.Log(string.Format("Adding {0} to quest log", quest.name));
        currentQuests.Add(quest);

        onQuestChangedCallback.Invoke();

        return true;
    }

    public bool QuestCompleted(Quest quest)
    {
        if (currentQuests.Find(q => q.name.Equals(quest.name)) != null)
        {
            return quest.completed;
        }
        Debug.Log("Quest is not in log");
        return false;
    }

    public void Remove(Quest quest)
    {
        Debug.Log(string.Format("Removing {0} from quest log", quest.name));
        currentQuests.Remove(quest);
        onQuestChangedCallback.Invoke();
    }
}
