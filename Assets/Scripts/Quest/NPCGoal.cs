using UnityEngine;

[CreateAssetMenu(fileName = "New NPC Goal", menuName = "Goals/NPCGoal")]
public class NPCGoal : Goal
{
    public int npcId;

    public override void Init()
    {
        base.Init();
        completed = false;
        NPCEvents.OnNPCInteract += NPCInteracted;
    }

    void NPCInteracted(NPC npc)
    {
        Debug.Log("Npc interacted: " + npc.ID + " wanted: " + npcId);
        if (npc.ID == this.npcId)
        {
            Debug.Log("Requirements met");
            Complete();
        }
    }
}
