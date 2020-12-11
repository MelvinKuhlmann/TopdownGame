using UnityEngine;

[CreateAssetMenu(fileName = "New Goal", menuName = "Goals/Goal")]
public class Goal : ScriptableObject
{
    public string description;
    public bool completed { get; set; }

    public virtual void Init()
    {
        // default init stuff
    }

    public virtual void Evaluate()
    {
        // default evaluate stuff
    }

    public void Complete()
    {
        //quest.CheckGoals();
        completed = true;
        Debug.Log("Mark quest as completed");
    }


}
