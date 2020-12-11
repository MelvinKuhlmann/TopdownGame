using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltimateSlayer : Quest
{
    
    void Start()
    {
        questName = "Ultimate Slayer";
        description = "Kill bunch of goblins";
        itemReward = null;//set an item here
        experienceReward = 100;

        goals.Add(new KillGoal(this, 0, "Kill 5 goblins", false, 0, 5));
        goals.Add(new KillGoal(this, 1, "Kill 2 vampires", false, 0, 2));

        goals.ForEach(g => g.Init());
    }

   
}
