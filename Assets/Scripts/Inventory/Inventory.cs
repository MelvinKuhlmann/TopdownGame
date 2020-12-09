using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;

    public int space = 20;

    public List<Object> items = new List<Object>();

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

    // This method returns true if the item is succesfully added, false otherwise.
    public bool Add(Object item)
    {
        if (items.Count >= space)
        {
            Debug.Log("No room in inventory!");
            return false;
        }
        items.Add(item);
        return true;
    } 

    public void Remove(Object item)
    {
        items.Remove(item);
    }
}
