using TMPro;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public abstract int id { get; }

    public abstract int maxHealth { get; }

    public abstract int experience { get; }
    public abstract int level { get; }

    public abstract int moveSpeed { get; }

    public new abstract string name { get; }

    public int currentHealth { get; set; }

    public TMP_Text levelInfo;
    public TMP_Text nameInfo;

    public void Start()
    {
        currentHealth = maxHealth;
        levelInfo.text = string.Format("Lv. {0}", level);
        nameInfo.text = name;
    }

    protected void Die()
    {
        CombatEvents.EnemyDied(this);
    }

    protected void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Implement this method for adding attack logic
    /// </summary>
    protected abstract void PerformAttack();
}
