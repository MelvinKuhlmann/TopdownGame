using UnityEngine;

public class CombatEvents : MonoBehaviour
{
    public delegate void EnemyEventHandler(IEnemy enemy);
    public static event EnemyEventHandler OnEnemyDeath;

    public static void EnemyDied(IEnemy enemy)
    {
        if (OnEnemyDeath != null)
        {
            OnEnemyDeath(enemy);
        }
    }
}
