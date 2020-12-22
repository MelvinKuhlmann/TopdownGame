using UnityEngine;

public class NpcInteractionController : MonoBehaviour
{
    public static NpcInteractionController instance;
    public GameObject npcInteractionPanel;
    public GameObject talkButton;
    public GameObject questButton;

    private NPC npc;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public bool IsActive()
    {
        return npcInteractionPanel.activeInHierarchy;
    }

    public void SetNPC(NPC npc)
    {
        this.npc = npc;
        if (npc.availableQuests != null && npc.availableQuests.Count > 0)
        {
            questButton.SetActive(true);
        } else
        {
            questButton.SetActive(false);
        }
        npcInteractionPanel.SetActive(true);
    }

    public void RemoveNPC()
    {
        npc = null;
        npcInteractionPanel.SetActive(false);
    }

    public void Talk()
    {
        if(!DialogManager.instance.IsActive())
        {
            npc.Talk();
        } else
        {
            DialogManager.instance.Nextline();
        }
    }

    public void Quest()
    {
        npc.Quests();
    }
}
