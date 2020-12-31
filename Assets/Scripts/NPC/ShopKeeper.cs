using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : NPC
{
    [Header("Shop")]
    public List<Item> itemsInShop;

    public void Shop()
    {
        ShopUI.instance.OpenShop(itemsInShop);
    }
}
