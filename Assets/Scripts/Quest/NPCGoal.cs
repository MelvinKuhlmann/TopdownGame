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
        Debug.Log(string.Format("Npc {0} interacted. Required for quest: {1}", npc.ID, npcId));
        if (npc.ID == this.npcId)
        {
            Complete();
        }
    }
}
