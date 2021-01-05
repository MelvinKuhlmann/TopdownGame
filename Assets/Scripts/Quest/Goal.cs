using UnityEngine;

[CreateAssetMenu(fileName = "New Goal", menuName = "Goals/Goal")]
public class Goal : ScriptableObject
{
    public string id;
    public string description;
    public bool completed { get; set; }

    private bool broadcastCompletion = false;

    public virtual void Init()
    {
        // default init stuff
        completed = false;
        broadcastCompletion = false;
    }

    public virtual void Evaluate()
    {
        // default evaluate stuff
    }

    public void Complete()
    {
        completed = true;
        if (!broadcastCompletion)
        {
            QuestEvents.GoalCompleted(this);
            broadcastCompletion = true;
        }
    }
}
