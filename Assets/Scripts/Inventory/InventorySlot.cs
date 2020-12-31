using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private Item item;

    public Image icon;
    public Button inventorySlotButton;

    public void AddItem(Item item)
    {
        this.item = item;

        icon.sprite = item.icon;
        icon.enabled = true;

        inventorySlotButton.interactable = true;
    }

    public void ClearSlot()
    {
        item = null;

        icon.sprite = null;
        icon.enabled = false;

        inventorySlotButton.interactable = false;
    }

    public void UseItem()
    {
        item.Use();
    }
}
