using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private Inventory inventory;
    private InventorySlot[] inventorySlots;

    public void Start()
    {
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        UpdateUI();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            gameObject.SetActive(!gameObject.activeInHierarchy);
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
