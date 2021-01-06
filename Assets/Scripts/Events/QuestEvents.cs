using UnityEngine;

public class QuestEvents : MonoBehaviour
{
    public delegate void GoalEventHandler(Goal goal);
    public static event GoalEventHandler OnGoalComplete;

    public delegate void KillGoalEventHandler(KillGoal goal, Enemy enemy);
    public static event KillGoalEventHandler OnEnemyKilled;

    public delegate void QuestEventHandler(Quest quest);
    public static event QuestEventHandler OnQuestComplete;

    public delegate void QuestLogEventHandler(Quest quest);
    public static event QuestLogEventHandler OnQuestClicked;

    public static void GoalCompleted(Goal goal)
    {
        OnGoalComplete?.Invoke(goal);
    }

    public static void EnemyKilled(KillGoal goal, Enemy enemy)
    {
        OnEnemyKilled?.Invoke(goal, enemy);
    }

    public static void QuestCompleted(Quest quest)
    {
        OnQuestComplete?.Invoke(quest);
    }

    public static void QuestClicked(Quest quest)
    {
        OnQuestClicked?.Invoke(quest);
    }
}
