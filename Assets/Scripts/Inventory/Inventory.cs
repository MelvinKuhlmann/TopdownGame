using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Inventory System/Inventory")]
public class Inventory : ScriptableObject
{
    [SerializeField]
    private List<InventoryItemWrapper> items = new List<InventoryItemWrapper>();

    [SerializeField]
    private InventoryUI inventoryUI;

    private Dictionary<InventoryItem, int> itemToCountMap = new Dictionary<InventoryItem, int>();

    public void Init()
    {
        for (int i = 0; i < items.Count; i++)
        {
            itemToCountMap.Add(items[i].GetItem(), items[i].GetItemCount());
        }
    }

    public void AssignItemToPlayer(InventoryItem item)
    {
        Debug.Log(string.Format("Player assigned {0}", item.GetName()));
    }

    public Dictionary<InventoryItem, int> getAllItems()
    {
        return itemToCountMap;
    }

    public void AddItem(InventoryItem item, int count)
    {
        int currentItemCount;
        if (itemToCountMap.TryGetValue(item, out currentItemCount))
        {
            itemToCountMap[item] = currentItemCount + count;
        } else
        {
            itemToCountMap.Add(item, count);
        }

        // Update the UI
        inventoryUI.CreateOrUpdateSlot(item, count);
    }

    public void RemoveItem(InventoryItem item, int count)
    {
        int currentItemCount;
        if (itemToCountMap.TryGetValue(item, out currentItemCount))
        {
            itemToCountMap[item] = currentItemCount - count;

            // Update the UI
            if (currentItemCount - count <= 0)
            {
                inventoryUI.DestroySlot(item);
            } else
            {
                inventoryUI.UpdateSlot(item, currentItemCount - count);
            }
        }
        else
        {
            Debug.Log(string.Format("Can't remove item {0} from Inventory because it does not exist.", item.GetName()));
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
