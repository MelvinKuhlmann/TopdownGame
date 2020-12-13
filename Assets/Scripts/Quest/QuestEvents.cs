using UnityEngine;

public class QuestEvents : MonoBehaviour
{
    public delegate void QuestEventHandler(Goal goal);
    public static event QuestEventHandler OnGoalComplete;

    public static void GoalCompleted(Goal goal)
    {
        if (OnGoalComplete != null)
        {
            OnGoalComplete(goal);
        }
    }
}
