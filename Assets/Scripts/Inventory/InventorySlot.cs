using UnityEngine;
using UnityEngine.UI;

public class InventorySlot : MonoBehaviour
{
    private InventoryItem inventoryItem;

    public Image icon;

    public void AddItem(InventoryItem item)
    {
        inventoryItem = item;

        icon.sprite = item.GetItemIcon();
        icon.enabled = true;
    }

    public void ClearSlot()
    {
        inventoryItem = null;

        icon.sprite = null;
        icon.enabled = false;
    }

    public void UseItem()
    {
        Debug.Log(string.Format("Using item {0}", inventoryItem.GetItemName()));
    }
}
