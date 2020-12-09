using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem : ScriptableObject
{
    [SerializeField]
    private GameObject prefab { get; }

    [SerializeField]
    private Sprite sprite { get; }

    [SerializeField]
    private string name { get; }

    public GameObject GetPrefab()
    {
        return prefab;
    }

    public Sprite GetSprite()
    {
        return sprite;
    }

    public string GetName()
    {
        return name;
    }
}
