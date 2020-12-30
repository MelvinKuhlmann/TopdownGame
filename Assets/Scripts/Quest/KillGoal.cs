using UnityEngine;

[CreateAssetMenu(fileName = "New Kill Goal", menuName = "Goals/KillGoal")]
public class KillGoal : Goal
{
    public int enemyID;
    private int currentKills;
    public int requiredKills;

    public override void Init()
    {
        base.Init();
        currentKills = 0; //reset it again in the init, base class is ignored
        CombatEvents.OnEnemyDeath += EnemyDied;
    }

    void EnemyDied(IEnemy enemy)
    {
        if (enemy.ID == this.enemyID)
        {
            Debug.Log(string.Format("Enemy {0} thats belongs to a quest died. ", enemy.ID));
            currentKills++;
            Evaluate();
        }
    }

    public override void Evaluate()
    {
        Debug.Log(string.Format("Current Kills: {0}; Required kills: {1}", currentKills, requiredKills));
        if (currentKills >= requiredKills)
        {
            Complete();
        }
    }
}
