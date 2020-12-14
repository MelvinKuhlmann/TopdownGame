using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest")]
public class Quest : ScriptableObject {

    public bool completed { get; set; }

    public List<Goal> goals = new List<Goal>();
    public new string name;
    public string description;
    public int experienceReward;
    public Item itemReward;
    public int levelRequirement;

    public void Init()
    {
        completed = false;
        goals.ForEach(g => g.Init());
        QuestEvents.OnGoalComplete += GoalCompleted;
    }

    void GoalCompleted(Goal goal)
    {
        completed = goals.All(g => g.completed);

        if (completed)
        {
            Debug.Log("Quest completed: " + name);
        }
    }

    public void GiveReward()
    {
        if (itemReward != null)
        {
            Debug.Log("Call inventory system to give reward");
            Inventory.instance.Add(itemReward);
        }
        Debug.Log("Call playercontroller to give EXP");
        Player.instance.AddExp(experienceReward);
    }
}
