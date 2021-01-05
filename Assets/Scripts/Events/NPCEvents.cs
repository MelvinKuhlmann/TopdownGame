using UnityEngine;

public class NPCEvents : MonoBehaviour
{
    public delegate void NPCEventHandler(NPC npc);
    public static event NPCEventHandler OnNPCInteract;

    public static void OnNPCInteracted(NPC npc)
    {
        if (OnNPCInteract != null)
        {
            OnNPCInteract(npc);
        }
    }
}
