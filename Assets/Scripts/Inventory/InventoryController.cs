using System.Collections.Generic;
using UnityEngine;

public class InventoryController : MonoBehaviour
{
    #region Singleton
    public static InventoryController instance;

    private void Awake()
    {
        // Maybe refactor this once the inventory works and we want to network it.
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of InventoryController found");
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
    public List<Item> items = new List<Item>();

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
    public bool Add(Item item)
    {
        if (items.Count >= maxSpace)
        {
            Debug.Log("No room in inventory!");
            return false;
        }

        items.Add(item);

        onItemChangedCallback.Invoke();

        return true;
    } 

    public void Remove(Item item)
    {
        items.Remove(item);
        onItemChangedCallback.Invoke();
    }
}
