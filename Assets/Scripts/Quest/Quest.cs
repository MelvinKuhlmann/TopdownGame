using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest")]
public class Quest : ScriptableObject {

    public int id;
    public bool completed { get; set; }

    public List<Goal> goals = new List<Goal>();
    public new string name;
    public string description;
    public string completedDescription;
    public int experienceReward;
    public int shardsReward;
    public List<Item> itemRewards = new List<Item>();
    public int levelRequirement;

    private bool broadcastCompletion = false;

    public void Init()
    {
        completed = false;
        broadcastCompletion = false;
        goals.ForEach(g => g.Init());
        QuestEvents.OnGoalComplete += GoalCompleted;
    }

    void GoalCompleted(Goal goal)
    {
        completed = goals.All(g => g.completed);

        if (completed && !broadcastCompletion)
        {
            broadcastCompletion = true;
            QuestEvents.QuestCompleted(this);
        }
    }

    public void GiveReward()
    {
        itemRewards.ForEach(r => Inventory.instance.Add(r));
        Player.instance.AddExp(experienceReward);
        Inventory.instance.shards += shardsReward;
    }
}
