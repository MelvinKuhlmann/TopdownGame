using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    public Slider healthbar;

    public void Start()
    {
        currentHealth = maxHealth;
        levelInfo.text = level.ToString();
        nameInfo.text = name;
        healthbar.maxValue = maxHealth;
    }

    protected void Die()
    {
        CombatEvents.EnemyDied(this);
    }

    protected void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthbar.value = currentHealth;

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
