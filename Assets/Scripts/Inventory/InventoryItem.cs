﻿using System.Collections;
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

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
