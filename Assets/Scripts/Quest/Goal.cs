using UnityEngine;

[CreateAssetMenu(fileName = "New Goal", menuName = "Goals/Goal")]
public class Goal : ScriptableObject
{
    public string id;
    public string description;
    public bool completed { get; set; }

    public virtual void Init()
    {
        // default init stuff
        completed = false;
    }

    public virtual void Evaluate()
    {
        // default evaluate stuff
    }

    public void Complete()
    {
        completed = true;
        QuestEvents.GoalCompleted(this);
    }
}
