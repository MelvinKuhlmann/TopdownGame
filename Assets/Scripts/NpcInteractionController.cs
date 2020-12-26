using UnityEngine;

public class NpcInteractionController : MonoBehaviour
{
    public static NpcInteractionController instance;
    public GameObject npcInteractionPanel;
    public GameObject talkButton;
    public GameObject questButton;

    private Interactable interactable;

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

    public void SetInteractable(Interactable interactable)
    {
        this.interactable = interactable;
        if (interactable is NPC && ((NPC)interactable).availableQuests != null && ((NPC)interactable).availableQuests.Count > 0)
        {
            questButton.SetActive(true);
        } else
        {
            questButton.SetActive(false);
        }
        npcInteractionPanel.SetActive(true);
    }

    public void RemoveInteractable()
    {
        interactable = null;
        npcInteractionPanel.SetActive(false);
    }

    public void Talk()
    {
        if (!DialogManager.instance.IsActive())
        {
            interactable.Talk();
        } else
        {
            DialogManager.instance.Nextline();
        }
    }

    public void Quest()
    {
        ((NPC)interactable).Quests();
    }
}
