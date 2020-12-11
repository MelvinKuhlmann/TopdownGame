using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Quest : MonoBehaviour{

    public List<Goal> goals { get; set; } = new List<Goal>();
    public string questName { get; set; }
    public string description { get; set; }
    public int experienceReward { get; set; }
    public Item itemReward { get; set; }
    public bool completed { get; set; }

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
