using UnityEngine;

[CreateAssetMenu(fileName = "New Kill Goal", menuName = "Goals/KillGoal")]
public class KillGoal : Goal
{
    public int enemyID;
    private int currentKills = 0;
    public int requiredKills;

    public override void Init()
    {
        base.Init();
        CombatEvents.OnEnemyDeath += EnemyDied;
    }

    void EnemyDied(IEnemy enemy)
    {
        if (enemy.ID == this.enemyID)
        {
            currentKills++;
            Evaluate();
        }
    }
}
