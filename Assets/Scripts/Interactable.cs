using UnityEngine;

public class Interactable : MonoBehaviour
{
    [Header("Dialog")]
    public string[] lines;
    public bool isPerson = true;
    protected bool canActivate;

    void Update()
    {
        if (canActivate && Input.GetKeyDown(KeyCode.Return) && !DialogManager.instance.dialogBox.activeInHierarchy)
        {
            Interact();
        }
    }

    public virtual void Interact()
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
