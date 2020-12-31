using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopKeeper : NPC
{
    public void Shop()
    {
        ShopUI.instance.OpenShop();
    }
}
