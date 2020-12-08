using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItemWrapper : MonoBehaviour
{
    [SerializeField]
    private InventoryItem item;

    [SerializeField]
    private int itemCount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public InventoryItem GetItem()
    {
        return item;
    }

    public int GetItemCount()
    {
        return itemCount;
    }
}
