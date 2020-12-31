using UnityEngine;

public class Interactable : MonoBehaviour
{
    [Header("Dialog")]
    public string[] lines;
    public bool isPerson = true;
    protected bool canActivate;

    private bool uiActivated = false;

    private void Update()
    {
        if (canActivate && !NpcInteractionButtonsUI.instance.IsActive() && !uiActivated)
        {
            NpcInteractionButtonsUI.instance.SetInteractable(this);
            uiActivated = true;
        }
        else if (!canActivate && NpcInteractionButtonsUI.instance.IsActive() && uiActivated)
        {
            NpcInteractionButtonsUI.instance.RemoveInteractable();
            uiActivated = false;
        }
        UpdateHook();
    }
    public virtual void UpdateHook()
    {

    }

    public virtual void Talk()
    {
        DialogManager.instance.ShowDialog(lines, isPerson);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == Tag.Player.ToString())
        {
            canActivate = false;
            if (DialogManager.instance.dialogBox.activeInHierarchy)
            {
                DialogManager.instance.dialogBox.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == Tag.Player.ToString())
        {
            canActivate = true;
        }
    }
}
