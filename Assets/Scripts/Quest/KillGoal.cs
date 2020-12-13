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
        Debug.Log("Init");
        CombatEvents.OnEnemyDeath += EnemyDied;
    }

    void EnemyDied(IEnemy enemy)
    {
        Debug.Log("Enemy died: " + enemy.ID);
        if (enemy.ID == this.enemyID)
        {
            Debug.Log("Enemy died: " + enemy.ID + ", add 1 to currentKills");
            currentKills++;
            Evaluate();
        }
    }

    public override void Evaluate()
    {
        if (currentKills >= requiredKills)
        {
            completed = true;
            Debug.Log("Goal completed");
        }
    }
}
