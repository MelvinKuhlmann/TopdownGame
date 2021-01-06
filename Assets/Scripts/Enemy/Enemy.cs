using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class Enemy : MonoBehaviour
{
    private bool hittable;
    public abstract int id { get; }

    public abstract int maxHealth { get; }

    public abstract int experience { get; }
    public abstract int level { get; }

    public abstract int moveSpeed { get; }

    public new abstract string name { get; }

    public int currentHealth { get; set; }

    public Slider healthbar;
    public TMP_Text levelInfo;
    public TMP_Text nameInfo;
    public TMP_Text damageNumber;

    public Animator animator;

    public void Start()
    {
        hittable = true;
        currentHealth = maxHealth;
        levelInfo.text = level.ToString();
        nameInfo.text = name;
        healthbar.maxValue = maxHealth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int playerTotalWeaponPower = Player.instance.totalWeaponPower;

        if (Tag.Main_Hand.ToString().Equals(collision.collider.tag))
        {
            TakeDamage(Random.Range(playerTotalWeaponPower, playerTotalWeaponPower + Player.instance.baseWeaponRange));
        }
    }

    protected void Die()
    {
        ChangeAnimation("isDying");
    }

    protected void TakeDamage(int amount)
    {
        if (hittable)
        {
            ChangeAnimation("isHit");
            ShowDamageNumber(amount);

            currentHealth -= amount;
            healthbar.value = currentHealth;

            if (currentHealth <= 0)
            {
                Die();
            }

            hittable = false;
        }

    }

    /// <summary>
    /// Implement this method for adding attack logic
    /// </summary>
    protected abstract void PerformAttack();

    public void EnableHittable()
    {
        ChangeAnimation("isMoving");
        hittable = true;
    }

    public void Dead()
    {
        CombatEvents.EnemyDied(this);
        Destroy(gameObject);
    }

    private void ChangeAnimation(string animationFlag, bool resetAll = true)
    {
        if (resetAll)
        {
            ResetAnimationParameters();
        }
        animator.SetBool(animationFlag, true);
    }

    private void ResetAnimationParameters()
    {
        foreach (AnimatorControllerParameter parameter in animator.parameters)
        {
            animator.SetBool(parameter.name, false);
        }
    }

    public void ShowDamageNumber(int amount)
    {
        damageNumber.text = amount.ToString();
        damageNumber.GetComponent<Animator>().Play("Base Layer.DamageFloat");
    }
}
