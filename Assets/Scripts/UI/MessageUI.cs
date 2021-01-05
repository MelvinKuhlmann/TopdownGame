using TMPro;
using UnityEngine;

public class MessageUI : MonoBehaviour
{
    public TMP_Text text;
    public Animator animator;

    #region Singleton
    public static MessageUI instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of MessageUI found");
            return;
        }
        instance = this;

        QuestEvents.OnGoalComplete += GoalCompleted;
        QuestEvents.OnEnemyKilled += EnemyKilled;
        QuestEvents.OnQuestComplete += QuestCompleted;
    }
    #endregion

    void GoalCompleted(Goal goal)
    {
        text.text = string.Format("{0} completed", goal.description);
        animator.SetTrigger("Show");
    }

    void EnemyKilled(KillGoal goal, Enemy enemy)
    {
        text.text = string.Format("{0} ({1}/{2})", goal.description, goal.CurrentKills(), goal.requiredKills);
        animator.SetTrigger("Show");
    }

    void QuestCompleted(Quest quest)
    {
        text.text = string.Format("{0} completed", quest.name);
        animator.SetTrigger("Show");
    }

}
