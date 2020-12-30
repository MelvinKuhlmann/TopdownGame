using UnityEngine;
//using System.Collections;

public class InventoryUI : CloseUI
{
    private Inventory inventory;
    private InventorySlot[] inventorySlots;
    //Renderer rend;

    public void Start()
    {
        //rend = GetComponent<Renderer>();
        //rend.enabled = true;
        inventory = Inventory.instance;
        inventory.onItemChangedCallback += UpdateUI;

        UpdateUI();
    }

    void OnDisable()
    {
        Debug.Log("PrintOnDisable: Inventory is disabled");
    }

    void OnEnable()
    {
        Debug.Log("PrintOnEnable: Inventory was enabled");
    }

    private void Update()
    {
        //Debug.Log("Inventory screen");

        if (Input.GetKeyDown(KeyCode.I))
        {
            canvasGroup = GetComponent<CanvasGroup>();
            if (canvasGroup.alpha == 1)
            {
                Hide();
                Debug.Log("PrintOnEnable: Inventory was turned invisible");
            }
            else
            {
                Show();
                Debug.Log("PrintOnEnable: Inventory was turned visible");
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
