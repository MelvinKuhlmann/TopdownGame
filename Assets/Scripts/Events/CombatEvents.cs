using UnityEngine;

public class CombatEvents : MonoBehaviour
{
    public delegate void EnemyEventHandler(Enemy enemy);
    public static event EnemyEventHandler OnEnemyDeath;

    public static void EnemyDied(Enemy enemy)
    {
        OnEnemyDeath?.Invoke(enemy);
    }
}
