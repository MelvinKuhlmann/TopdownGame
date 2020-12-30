using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Singleton
    public static Inventory instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of InventoryController found");
            return;
        }

        instance = this;
    }
    #endregion

    public List<Item> items = new List<Item>();
    public int maxSpace = 20;

    // Callback which is triggered when
    // an item gets added/removed.
    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;

    // This method returns true if the item is succesfully added, false otherwise.
    public bool Add(Item item)
    {
        if (items.Count >= maxSpace)
        {
            Debug.Log("No room in inventory!");
            return false;
        }

        Debug.Log(string.Format("Adding {0} to inventory", item.name));
        items.Add(item);

        onItemChangedCallback.Invoke();

        return true;
    } 

    public void Remove(Item item)
    {
        Debug.Log(string.Format("Removing {0} from inventory", item.name));
        items.Remove(item);
        onItemChangedCallback.Invoke();
    }
}
