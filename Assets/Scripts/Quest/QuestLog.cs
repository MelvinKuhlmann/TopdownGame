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

        if (AlreadyAccepted(quest))
        {
            return false;
        }

        Debug.Log(string.Format("Adding {0} to quest log", quest.name));
        quest.Init();
        currentQuests.Add(quest);

        onQuestChangedCallback.Invoke();

        return true;
    }

    public bool AlreadyAccepted(Quest quest)
    {
        if (currentQuests.Find(currentQuest => currentQuest.id.Equals(quest.id)) != null)
        {
            return true;
        }
        return false;
    }

    public bool QuestCompleted(Quest quest)
    {
        if (currentQuests.Find(q => q.id.Equals(quest.id)) != null)
        {
            return quest.completed;
        }
        return false;
    }

    public void Remove(Quest quest)
    {
        currentQuests.Remove(quest);
        onQuestChangedCallback.Invoke();
    }
}
