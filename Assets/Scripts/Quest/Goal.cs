using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal
{
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
        completed = true;
    }


}
