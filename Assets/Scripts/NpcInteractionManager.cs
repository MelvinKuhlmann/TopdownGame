using UnityEngine;

public class NpcInteractionManager : MonoBehaviour
{
    public static NpcInteractionManager instance;
    public GameObject panel;
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
        return panel.activeInHierarchy;
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
        panel.SetActive(true);
    }

    public void RemoveInteractable()
    {
        interactable = null;
        panel.SetActive(false);
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
