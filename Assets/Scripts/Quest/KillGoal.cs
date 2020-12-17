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
        Debug.Log("Current Kills: " + currentKills + ", required kills: " + requiredKills);
        if (currentKills >= requiredKills)
        {
            Debug.Log("requirements met");
            Complete();
        }
    }
}
