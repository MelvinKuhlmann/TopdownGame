using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Security.Cryptography;
using UnityEngine;

public class KillGoal : Goal
{
    public int enemyID { get; set; }
    public KillGoal(Quest quest, int enemyID, string description, bool completed, int currentAmount, int requiredAmount)
    {
        this.quest = quest;
        this.enemyID = enemyID;
        this.description = description;
        this.completed = completed;
        this.currentAmount = currentAmount;
        this.requiredAmount = requiredAmount;
    }

    public override void Init()
    {
        base.Init();
        CombatEvents.OnEnemyDeath += EnemyDied;
        // continue watching: https://www.youtube.com/watch?v=h7rRic4Xoak 07:28
        // combat events: https://www.youtube.com/watch?v=ufDQuy3w_VQ&list=PLivfKP2ufIK6ToVMtpc_KTHlJRZjuE1z0&index=20
        // total list: https://www.youtube.com/playlist?list=PLivfKP2ufIK6ToVMtpc_KTHlJRZjuE1z0
    }

    void EnemyDied(IEnemy enemy)
    {
        if (enemy.ID == this.enemyID)
        {
            this.currentAmount++;
            Evaluate();
        }
    }
}
