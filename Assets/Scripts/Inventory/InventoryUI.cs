using UnityEngine;

public class InventoryUI : TogglebleUI
{
    private Inventory inventory;
    private InventorySlot[] inventorySlots;

    public void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;
        canvasGroup = GetComponent<CanvasGroup>();

        Hide();
        UpdateUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (canvasGroup.alpha == 1)
            {
                Hide();
            }
            else
            {
                Show();
            }
        }
    }

    void UpdateUI()
    {
        inventorySlots = transform.GetComponentsInChildren<InventorySlot>();

        for (int i = 0; i < inventory.items.Count; i++)
        {
            inventorySlots[i].ClearSlot();
            inventorySlots[i].AddItem(inventory.items[i]);
        }
    }
}
