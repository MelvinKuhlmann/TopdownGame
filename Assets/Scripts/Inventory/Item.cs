using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName ="Inventory/Item")]
public class Item : ScriptableObject
{
    public Sprite itemIcon;
    public string itemName;
    public string itemCategory;
    public string itemTooltip;
    public bool isQuestItem;

    public virtual void Use()
    {
        Debug.Log("Using" + itemName);
    }
}
