using UnityEngine;

[CreateAssetMenu(fileName = "New Collect Goal", menuName = "Goals/CollectGoal")]
public class CollectGoal : Goal
{
    private int currentCollected;
    public int requiredCollected;

    public override void Init()
    {
        base.Init();
    }
}
