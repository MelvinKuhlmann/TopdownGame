﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal
{
    public Quest quest { get; set; }
    public string description { get; set; }
    public bool completed { get; set; }
    public int currentAmount { get; set; }
    public int requiredAmount { get; set; }

    public virtual void Init()
    {
        // default init stuff
    }

    public void Evaluate()
    {
        if (currentAmount >= requiredAmount)
        {
            Complete();
        }
    }

    public void Complete()
    {
        quest.CheckGoals();
        completed = true;
        Debug.Log("Mark quest as completed");
    }


}
