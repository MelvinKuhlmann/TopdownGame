using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour, IEnemy
{
    public int currentHealth;
    public int maxHealth;
    public int ID { get; set;}
    public int experience { get; set; }

    public void Die()
    {
        Debug.Log("Enemy die");
        CombatEvents.EnemyDied(this);
    }

    public void PerformAttack()
    {
        //TODO
    }

    public void TakeDamage(int amount)
    {
        Debug.Log("Damage taken: " + amount);
        currentHealth -= amount;
        if (currentHealth <= 0) { 
            Die();
        }
    }

    void Start()
    {
        ID = 1;
        experience = 100;
        maxHealth = 10;
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.B))
        {
            TakeDamage(maxHealth);
        }
    }
}
