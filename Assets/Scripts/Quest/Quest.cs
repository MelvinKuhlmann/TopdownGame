using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu(fileName = "New Quest", menuName = "Quest")]
public class Quest : ScriptableObject {

    public bool completed { get; set; }

    public List<Goal> goals = new List<Goal>();
    public string questName;
    public string description;
    public int experienceReward;
    public Item itemReward;
    public int levelRequirement;

    public void CheckGoals()
    {
        completed = goals.All(g => g.completed);
    }

    public void GiveReward()
    {
        if (itemReward != null)
        {
            Debug.Log("Call inventory system to give reward");
        }
        Debug.Log("Call playercontroller to give EXP");
    }


   /* public bool isActive;

    public string title;
    public string description;
    public int experienceReward;
    public int goldReward;*/
}
