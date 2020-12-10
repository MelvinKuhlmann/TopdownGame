using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName ="Inventory/Quest Item")]
public class QuestItem : Item
{
    public override void Use()
    {
        Debug.Log(string.Format("Using quest item: {0}", itemName));
    }
}
