using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class is a ScriptableObject wrapper that basically keeps the information 
// of the picked up items to be displayed in the Inventory
public class InventoryItem : ScriptableObject
{
    private string itemName;
    private Sprite itemIcon;

    public InventoryItem(string name, Sprite icon)
    {
        this.itemName = name;
        this.itemIcon = icon;
    }

    public string GetItemName()
    {
        return itemName;
    }

    public void SetItemName(string name)
    {
        itemName = name;
    }
    public Sprite GetItemIcon()
    {
        return itemIcon;
    }

    public void SetItemIcon(Sprite sprite)
    {
        this.itemIcon = sprite;
    }
}
