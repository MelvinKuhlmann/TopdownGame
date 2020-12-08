using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable Objects/Inventory System/Inventory")]
public class Inventory : ScriptableObject
{
    [SerializeField]
    private List<InventoryItemWrapper> items = new List<InventoryItemWrapper>();

    private Dictionary<InventoryItem, int> itemToCountMap = new Dictionary<InventoryItem, int>();

    public void Init()
    {
        for (int i = 0; i < items.Count; i++)
        {
            itemToCountMap.Add(items[i].GetItem(), items[i].GetItemCount());
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
