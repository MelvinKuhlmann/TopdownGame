﻿using UnityEngine;

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
        Debug.Log(string.Format("Using item: {0}", itemName));
    }

    public EquipmentController GetEquipmentController()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        return player.GetComponent<EquipmentController>();
    }
}
