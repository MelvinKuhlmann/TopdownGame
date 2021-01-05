using UnityEngine;
public class QuestEvents : MonoBehaviour
{
    public delegate void GoalEventHandler(Goal goal);
    public static event GoalEventHandler OnGoalComplete;

    public delegate void KillGoalEventHandler(KillGoal goal, IEnemy enemy);
    public static event KillGoalEventHandler OnEnemyKilled;

    public delegate void QuestEventHandler(Quest quest);
    public static event QuestEventHandler OnQuestComplete;

    public delegate void QuestLogEventHandler(Quest quest);
    public static event QuestLogEventHandler OnQuestClicked;

    public static void GoalCompleted(Goal goal)
    {
        if (OnGoalComplete != null)
        {
            OnGoalComplete(goal);
        }
    }

    public static void EnemyKilled(KillGoal goal, IEnemy enemy)
    {
        if (OnEnemyKilled != null)
        {
            OnEnemyKilled(goal, enemy);
        }
    }

    public static void QuestCompleted(Quest quest)
    {
        if (OnQuestComplete != null)
        {
            OnQuestComplete(quest);
        }
    }

    public static void QuestClicked(Quest quest)
    {
        if (OnQuestClicked != null)
        {
            OnQuestClicked(quest);
        }
    }
}
