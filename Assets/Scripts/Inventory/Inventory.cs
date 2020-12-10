using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        // Maybe refactor this once the inventory works and we want to network it.
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of Inventory found");
            return;
        }

        instance = this;
    }
    #endregion

    private GameObject inventory;

    // Callback which is triggered when
    // an item gets added/removed.
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    public int maxSpace = 20;
    public List<InventoryItem> items = new List<InventoryItem>();

    private void Start()
    {
        // Initialize the inventory
        inventory = GameObject.FindGameObjectWithTag("Inventory");
        InventoryUI inventoryUI = inventory.GetComponent<InventoryUI>();
        inventoryUI.Initialize();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            inventory.SetActive(!inventory.activeInHierarchy);
        }
    }

    // This method returns true if the item is succesfully added, false otherwise.
    public bool Add(InventoryItem inventoryItem)
    {
        if (items.Count >= maxSpace)
        {
            Debug.Log("No room in inventory!");
            return false;
        }

        items.Add(inventoryItem);

        onItemChangedCallback.Invoke();

        return true;
    } 

    public void Remove(InventoryItem inventoryItem)
    {
        items.Remove(inventoryItem);
        onItemChangedCallback.Invoke();
    }
}
