using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestList : MonoBehaviour
{
    #region Singleton
    public static QuestList instance;

    private void Awake()
    {
        // Maybe refactor this once the inventory works and we want to network it.
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of QuestList found");
            return;
        }

        instance = this;
    }
    #endregion

    public delegate void OnQuestChanged();
    public OnQuestChanged onQuestChangedCallback;
}
