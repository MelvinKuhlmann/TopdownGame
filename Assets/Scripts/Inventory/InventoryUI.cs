using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private InventoryController inventory;
    private InventorySlot[] inventorySlots;

    public Transform itemsParent;
    
    public void Initialize()
    {
        inventory = InventoryController.instance;
        inventory.onItemChangedCallback += UpdateUI;

        UpdateUI();
    }

    void UpdateUI()
    {
        inventorySlots = itemsParent.GetComponentsInChildren<InventorySlot>();

        for (int i = 0; i < inventory.items.Count; i++)
        {
            inventorySlots[i].ClearSlot();
            inventorySlots[i].AddItem(inventory.items[i]);
        }
    }
}
