
public interface IEnemy 
{
    int ID { get; set; }
    int experience { get; set; }
    void Die();
    void TakeDamage(int amount);
    void PerformAttack();
}
