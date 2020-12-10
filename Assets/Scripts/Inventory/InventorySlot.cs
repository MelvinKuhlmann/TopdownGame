using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private InventoryItem inventoryItem;

    public Image icon;

    public Button inventorySlotButton;

    public void AddItem(InventoryItem item)
    {
        inventoryItem = item;

        icon.sprite = item.GetItemIcon();
        icon.enabled = true;

        inventorySlotButton.interactable = true;
    }

    public void ClearSlot()
    {
        inventoryItem = null;

        icon.sprite = null;
        icon.enabled = false;

        inventorySlotButton.interactable = false;
    }

    public void UseItem()
    {
        Debug.Log(string.Format("Using item {0}", inventoryItem.GetItemName()));
    }
}
