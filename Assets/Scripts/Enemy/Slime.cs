using UnityEngine;

public class Slime : Enemy
{
    public override int id => 2;
    public override string name => "Slime";

    public override int maxHealth => 20;

    public override int experience => 20;

    public override int level => 2;

    protected override void PerformAttack()
    {
        throw new System.NotImplementedException();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.B))
        {
            TakeDamage(maxHealth);
        }
    }
}
