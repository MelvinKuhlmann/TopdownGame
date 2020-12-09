using UnityEngine;
using System.Collections.Generic;
using System;

public class InventoryUI : MonoBehaviour
{
    [SerializeField]
    private Transform slotsParent;

    [SerializeField]
    private InventorySlot slotPrefab;

    private Dictionary<InventoryItem, InventorySlot> currentItemsInInventory = new Dictionary<InventoryItem, InventorySlot>();

    public void InitInventoryUI(Inventory inventory)
    {
        var items = inventory.getAllItems();

        foreach(var item in items)
        {
            CreateOrUpdateSlot(inventory, item.Key, item.Value);
        }
    }

    public void CreateOrUpdateSlot(Inventory inventory, InventoryItem item, int count)
    {
        if (!currentItemsInInventory.ContainsKey(item)) {
            InventorySlot slot = CreateSlot(inventory, item, count);
            currentItemsInInventory.Add(item, slot);
        } else
        {
            UpdateSlot(item, count);
        }
    }

    public void UpdateSlot(InventoryItem item, int count)
    {
        currentItemsInInventory[item].UpdateSlotCount(count);
    }

    public InventorySlot CreateSlot(Inventory inventory, InventoryItem item, int count)
    {
        InventorySlot newInventorySlot = Instantiate(slotPrefab, slotsParent);
        newInventorySlot.InitSlotVisualisation(item.GetSprite(), item.GetName(), count);
        newInventorySlot.AssignButtonCallback(() => inventory.AssignItemToPlayer(item));

        return newInventorySlot;
    }

    private void DestroySlot(InventoryItem inventoryItem)
    {
        Destroy(currentItemsInInventory[inventoryItem].gameObject);
        currentItemsInInventory.Remove(inventoryItem);
    }
}
